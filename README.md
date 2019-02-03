# Milkyway

Milkyway is playground for discovering:

- Linux development
- ASP Net Core
- Docker containers
- Kubernetes
- Istio

## Setup
- Install vscode
- Install aspnetcore sdk
- Install Docker
- Install Kubernetes CLI
- Install Minikube (kubernetes cluster to be run on laptop)
- Install Istio

## ASP Net Core

To add a package:
```
dotnet add <project_name>.csproj package <package_name>
``` 

## Docker
To build a docker image:

```bash
cd <project_dir>
docker build -t <image_name> .
``` 
To run a container from a docker image:

```bash
docker run -d -p 8080:80 --name <container_name> <image_name>
```

## Kubernetes (K8)

### Local K8 cluster
You can install minikube which is a Kubernetes cluster for a laptop configuration

The basic commands are:
``` bash
minikube start
minikube stop
minikube delete
```

### K8 dashboard
To access to Kubernetes dashboard:
```bash
kubectl proxy
```

In a web browser open `http://localhost:8001/api/v1/namespaces/kube-system/services/kubernetes-dashboard/proxy/#!/cluster?namespace=default`

If you encounter some issue, you may try to restart the minikube cluster.


## Istio

