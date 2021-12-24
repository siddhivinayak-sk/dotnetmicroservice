pipeline {  
  agent {
    dockerfile {
	  filename 'Dockerfile.build'
          args '-u 0:0 -v /var/run/docker.sock:/var/run/docker.sock'
	  label 'Ubuntu'
	}
  }
  
  environment {
    HOME = '/tmp'
  }
  
  stages {
    stage('Build') {
      steps {
        sh 'dotnet restore'
        sh 'dotnet clean'
        sh 'dotnet build'
      }
    }
    
    stage('Test') {
      steps {
        sh 'dotnet test'
      }
    }    
    
    stage('Package') {
      steps {
        sh "docker build -t rakeshhcl11/myproject:latest -f ./MyProject/Dockerfile ./"
        sh "docker login -u rakeshhcl11 -p Auss13******"
    	sh "docker push rakeshhcl11/myproject:latest"            
      }
    }

    stage('Analysis') {
      steps {
		sh "dotnet /sonar-scanner/SonarScanner.MSBuild.dll begin /k:MyProject /d:sonar.host.url='http://3.110.195.4:9000'"
		sh "dotnet build"
		sh "dotnet /sonar-scanner/SonarScanner.MSBuild.dll end"
	  }
	}
  }
  	
  post { 
    always {
	  sh "chmod -R 777 ./*" 
	  sh "chmod -R 777 ./.*"
	  deleteDir()
	  cleanWs()
	}
  }
}
