pipeline {
    agent { label 'linux' }
    options {
        buildDiscarder(logRotator(numToKeepStr:'10'))
        timeout(time: 15, unit: 'MINUTES')
        skipDefaultCheckout()
    }
    stages { 
        stage('Checkout') {
            steps {
				sh 'git config --global user.email "34026207+nuke-bot@users.noreply.github.com" && git config --global user.name "nuke-bot"'
				checkout scm
            }
        }
        stage('Pack') {
            steps {
                sh '/bin/bash ./build.sh Pack'
                archiveArtifacts 'output/*'
            }
        }
        
    }
}
