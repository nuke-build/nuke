pipeline {
    agent { node { label 'linux'} }
    options {
        timeout(time: 15, unit: 'MINUTES')
        ansiColor('xterm')
        skipDefaultCheckout()
    }

    stages {
        stage('Checkout') {
            steps {
				sh 'git config --global user.email "34026207+nuke-bot@users.noreply.github.com" && git config --global user.name "nuke-bot"'
				checkout scm
            }
        }
        stage('Release') {
            environment {
                GitHubApiKey = credentials('github_token_nuke_client')
                NuGetApiKey = credentials('nuget_token_arodus')
            }
            steps {
                script {
                    sshagent(['github_ssh_nuke']) {
                        sh '/bin/bash build.sh PrepareRelease+Release'
                    }
                }
				archiveArtifacts 'output/*.nupkg'
            }
        }
    }
    post {
        always {
            script {
                githubNotify('github_user_nuke','nuke-build', 'nswag')
            }
        }
    }
}

String getCommitSha() {
    return sh(returnStdout: true, script: 'git rev-parse HEAD').trim()
}

void githubNotifyPending(String credentialsId, String owner, String repo, String context = null) {
    context = context || env.JOB_NAME
    githubNotify(account: owner,
        context: context,
        credentialsId: credentialsId,
        description: description,
        repo: repo,
        sha: "${getCommitSha()}",
        status: 'PENDING',
        targetUrl: env.RUN_DISPLAY_URL
    )
}

void githubNotify(String credentialsId, String owner, String repo, String context = null) {
    context = context || env.JOB_NAME

    String description = ''
    String status = ''
    switch(currentBuild.currentResult) {
        case 'SUCCESS': 
            description = 'Build finished succesfully.'
            status = 'SUCCESS'
        break
        case 'UNSTABLE': 
            description = 'Build finished with warnings.' 
            status = 'ERROR'
        break
        case 'FAILURE': 
            description = 'Build finished.'
            status = 'FAILURE'
        break
        case 'NOT_BUILT':
            description = 'Build was skipped.'
            status = 'FAILURE'
        break
        case 'ABORTED':
            description = 'Build was aborted.'
            status = 'SUCCESS'
        break
    }
   
    githubNotify(account: owner,
        context: context,
        credentialsId: credentialsId,
        description: description,
        repo: repo,
        sha: "${getCommitSha()}",
        status: status,
        targetUrl: env.RUN_DISPLAY_URL
    )
}
