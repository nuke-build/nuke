pipeline {
    agent { label 'linux' }
    options {
        buildDiscarder(logRotator(numToKeepStr:'10'))
        timeout(time: 15, unit: 'MINUTES')
    }
    stages { 
		stage('DownloadPackages') {
            steps {
                sh '/bin/bash ./build.sh DownloadPackages'
            }
        }
        stage('Generate') {
            steps {
                sh '/bin/bash ./build.sh Generate -Skip -NoInit'
            }
        }
        stage('CompilePlugin') {
            steps {
                sh '/bin/bash ./build.sh CompilePlugin -Skip -NoInit'
            }
        }
        stage('Pack') {
            steps {
                sh '/bin/bash ./build.sh Pack -Skip -NoInit'
            }
			post {
				success {
					archiveArtifacts 'output/*'
				}
			}
        }
        
    }
}
