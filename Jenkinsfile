pipeline {
    agent {label 'linux' }
    options {
        buildDiscarder(logRotator(numToKeepStr:'10'))
        timeout(time: 15, unit: 'MINUTES')
    }
    stages {
        stage('Compile') {
            steps {
                sh '/bin/bash ./build.sh Compile'
            }
        }
        stage('Test') {
            steps {
               sh '/bin/bash ./build.sh Test -Skip -NoInit'
            }
            post {
                always {
                    step([$class: 'XUnitPublisher', testTimeMargin: '3000', thresholdMode: 1, thresholds: [[$class: 'FailedThreshold', failureThreshold: '0']], tools: [[$class: 'XUnitDotNetTestType', deleteOutputFiles: false, failIfNotNew: false, pattern: 'output/tests.xml', skipNoTestFiles: false, stopProcessingIfError: true]]])
                }
            }
        }
        stage('Publish') {
            steps {
                sh '/bin/bash ./build.sh Publish -Skip -NoInit'
            }
        }
        stage('Pack') {
            steps {
                sh '/bin/bash ./build.sh Pack -Skip -NoInit'
            }
        }
        
    }
}
