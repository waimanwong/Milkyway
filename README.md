# Milkyway

Milkyway is playground for discovering:

- Linux development
- ASP Net Core
- Docker containers
- Kubernetes
- Istio

## Setup
- Install vscode
https://code.visualstudio.com/docs/setup/linux

- Install .NET core sdk (depends on your linux distribution)
https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-current

- Install Docker
https://www.digitalocean.com/community/tutorials/how-to-install-and-use-docker-on-ubuntu-18-04

- Install Kubernetes CLI
https://kubernetes.io/docs/tasks/tools/install-kubectl/#install-with-snap-on-ubuntu

- Install Microk8 (kubernetes cluster to be run on laptop)
https://microk8s.io/

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

### MicroK8
MicroK8 is a K8 package which includes istio. 

To install MicroK8:
```bash
sudo snap install microk8s --classic
```
Then enable the services:
```bash
microk8s.enable dashboard registry istio proxy ...
``` 

To access Kuerbetes dashboard:
```bash
kubectl proxy
```

Then open the dashboard : http://localhost:8001/api/v1/namespaces/kube-system/services/https:kubernetes-dashboard:/proxy/

