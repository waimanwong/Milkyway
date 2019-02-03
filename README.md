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

Kubernetes needs a private local repository. The following commands creates a local repository
```bash
docker run -d -p 5000:5000 --restart=always --name registry registry:2
docker tag <image_name> localhost:5000/<image_name>
docker push localhost:5000/<image>
```


## Kubernetes (K8)

### Minikube
Minikube is a single node kubernetes cluster.

You can install Minikube on Linux by downloading a static binary:
```bash
curl -Lo minikube https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64 && chmod +x minikube
```
Here’s an easy way to add the Minikube executable to your path:

```bash
sudo cp minikube /usr/local/bin && rm minikube
```

To start minikube:
```bash 
sudo minikube start --vm-driver none
```
The flag --vm-driver none means that minike is not run in a virutalized server.

To start kubernetes dashboard:
```bash
sudo minikube dashboard
```
The command shoudl open the browser at the dashboard url.
You may encounter issue with xdg-open. In this case, you need to browse to the printed url on stdout.

### Deployment yaml file

A kubernetes deployment file describes the docker container to deploy and the expected state. 
The following is a sample kubernetes deployment file where the container is replicated 3 times.

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: webservice1-deployment
  labels:
    app: webservice1
spec:
  replicas: 3
  selector:
    matchLabels:
      app: webservice1
  template:
    metadata:
      labels:
        app: webservice1
    spec:
      containers:
      - name: webservice1
        image: localhost:5000/webservice1
        ports:
        - containerPort: 80
```

To create the deployment in kubernetes:
```bash
kubectl create -f <deployment_file_path>
```

To check the created deployments:
```bash
kubectl get deployments
```
