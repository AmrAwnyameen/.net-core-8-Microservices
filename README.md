<h1 align="center">Microservices Architecture with .NET 8</h1>
<h3 align="center">
  A demonstration of a microservices architecture using .NET 8, Docker, Kubernetes, gRPC, SQL Server, and In-Memory Database.
</h3>



<h3 align="left">Technologies Used:</h3>
## Microservices Architecture Demonstration

This project showcases a **microservices architecture** using the following technologies:

1. **.NET 8** - for building and running the microservices.
2. **Docker** - for containerizing the microservices.
3. **Kubernetes** - for orchestrating the Docker containers and managing scalability.
4. **gRPC** - for communication between the microservices.
5. **SQL Server** - for persistent data storage.
6. **In-Memory Database (InMemoryDB)** - for faster data operations in certain services.



<p align="left">
  <!-- Docker -->
  <a href="https://www.docker.com/" target="_blank">
    <img src="https://www.vectorlogo.zone/logos/docker/docker-icon.svg" alt="Docker" width="40" height="40"/>
  </a>
  <!-- Kubernetes -->
  <a href="https://kubernetes.io/" target="_blank">
    <img src="https://www.vectorlogo.zone/logos/kubernetes/kubernetes-icon.svg" alt="Kubernetes" width="40" height="40"/>
  </a>
  <!-- .NET -->
  <a href="https://dotnet.microsoft.com/" target="_blank">
    <img src="https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg" alt=".NET" width="40" height="40"/>
  </a>
  <!-- gRPC -->
  <a href="https://grpc.io/" target="_blank">
    <img src="https://grpc.io/img/logos/grpc-icon-color.png" alt="gRPC" width="40" height="40"/>
  </a>
  <!-- SQL Server -->
  <a href="https://learn.microsoft.com/en-us/sql/sql-server/" target="_blank">
    <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="SQL Server" width="40" height="40"/>
  </a>
  <!-- In-Memory Database -->
  <a href="https://learn.microsoft.com/en-us/ef/core/providers/in-memory/" target="_blank">
    <img src="https://www.vectorlogo.zone/logos/sqlite/sqlite-icon.svg" alt="InMemoryDB" width="40" height="40"/>
  </a>
  <!-- C# -->
  <a href="https://learn.microsoft.com/en-us/dotnet/csharp/" target="_blank">
    <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="C#" width="40" height="40"/>
  </a>
</p>


<hr>

<h3 align="left">Project Overview:</h3>
<p align="left">
  This project demonstrates a microservices architecture using .NET 8. It includes services for handling different aspects of the application, with inter-service communication managed by gRPC and messaging handled through a message bus.
</p>

<h3 align="left">Setup and Configuration:</h3>
<ul>
  <li>Clone the repository: <code>git clone https://github.com/yourusername/yourrepository.git</code></li>
  <li>Navigate to the project directory: <code>cd yourrepository</code></li>
  <li>Build and run the Docker containers: <code>docker-compose up</code></li>
  <li>Access the application at <code>http://localhost:5001</code></li>
</ul>

<h3 align="left">Additional Resources:</h3>
Microservices notes  commands:

Platform Micro packages:
------------------------------------------------------------------------------------------------------------------------------
⦁	Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
⦁	 Install-Package Microsoft.EntityFrameworkCore
⦁	Install-Package Microsoft.EntityFrameworkCore.Design 
⦁	Install-Package Microsoft.EntityFrameworkCore.InMemory
⦁	 Install-Package Microsoft.EntityFrameworkCore.SqlServer
⦁	 Install-Package Grpc.AspNetCore
⦁	 Install-Package Grpc.Net.Client
⦁	 Install-Package Grpc.Tools
⦁	 Install-Package Google.Protobuf
--------------------------------Docker---------------------------------------------------------------------------------------
⦁	 docker run -d -p 5000:5000 --name platformservice amrawniameen/platformservice
⦁	docker build -t amrawniameen/commandservice .
⦁	docker run -d -p 5000:5000 --name platformservice amrawniameen/platformservice
⦁	 docker run -d -p 5001:5001 --name commandservice amrawniameen/commandservice
⦁	docker run -p 8080:80  -d  
⦁	docker run -d -p 8000:8080  
⦁	docker ps
⦁	docker stop aebdb59255ae
⦁	Docker start aebdb59255ae
⦁	docker tag platformservice amrawniameen/platformservice:latest
⦁	docker push amrawniameen/platformservice:latest 
⦁	docker logs myplatformservice 
⦁	docker image build -t  amrawniameen/platformservice:8.0.0 .
⦁	docker-compose up --build 
⦁	 docker tag microservices-platformservice amrawniameen/platformservice:latest
⦁	docker run -d -p 5000:5000 --name platformservice amrawniameen/platformservice
⦁	docker run -d -p 5000:5000 --name platformservice -e ASPNETCORE_ENVIRONMENT=Development amrawniameen/platformservice
------------------Kubernates Config------------------------------------------------------------------------------------------
⦁	Install chocolaty packae mamanger Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.WebClient]::New().DownloadString('https://community.chocolatey.org/install.ps1') | Invoke-Expression
⦁	choco install minikube
⦁	minikube start
⦁	Kubectl version
⦁	Kubectl apply -f platforms-depl.yaml (deploy docker image)
⦁	Kubectl get deployment
⦁	Kubectl get pods
⦁	kubectl get services
⦁	kubectl delete deployments --all --all-namespaces
⦁	kubectl delete services --all
⦁	Kubectl rollout restart deployments platformservice
--------------Debug---K8s---------------------------------------------------------------------------------------------------------
⦁	kubectl delete services platforms-clusterip-srv
⦁	kubectl delete services platformnpservice-srv
⦁	Kubectl delete deployment platformservice
⦁	docker-compose up --build 
⦁	docker tag microservices-platformservice amrawniameen/platformservice:latest
⦁	docker tag commandservice-platformservice amrawniameen/commandservice:latest
⦁	docker push amrawniameen/platformservice:latest
⦁	Kubectl apply -f deployment.yaml 
⦁	Kubectl apply -f platforms-np-srv.yaml
⦁	Kubectl rollout restart deployments platformservice
⦁	Kubectl apply -f command-np-srv.yaml
⦁	Kubectl apply -f deployment.yaml
⦁	Kubectl apply -f command-np-srv
⦁	kubectl config use-context docker-desktop

---------------nginx---- setup--------------------------------------------------------------------------------------------------------
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.11.2/deploy/static/provider/cloud/deploy.yaml 
kubectl get pods -n ingress-nginx
kubectl get services -n ingress-nginx


<ul>
  <li><a href="https://docs.docker.com/get-started/" target="_blank">Docker Documentation</a></li>
  <li><a href="https://kubernetes.io/docs/home/" target="_blank">Kubernetes Documentation</a></li>
  <li><a href="https://docs.microsoft.com/en-us/dotnet/" target="_blank">.NET Documentation</a></li>
  <li><a href="https://grpc.io/docs/" target="_blank">gRPC Documentation</a></li>
  <li><a href="https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15" target="_blank">SQL Server Documentation</a></li>
</ul>

<hr>

<h3 align="left">Contributing:</h3>
<p align="left">
  If you would like to contribute to this project, please fork the repository and create a pull request with your changes.
</p>
