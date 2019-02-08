# Running SQLServer in a kubernetes cluster

https://joeydantoni.com/2018/04/05/getting-started-with-sql-sql-server-and-kubernetes-part-ii/

## Create a K8 secret for the sa user password
```bash
kubectl create secret generic mssql --from-literal=SA_PASSWORD="<pwd>"
```

## Declare a volume for the database
```yaml
kind: PersistentVolumeClaim
apiVersion: v1
metadata:
  name: mssql-data-claim
spec:
  accessModes:
  - ReadWriteOnce
  resources:
   requests:
    storage: 10Gi
```

## Deploy SQLServer
```yaml
apiVersion: v1
kind: Service
metadata:
  name: mssql-deployment
spec:
  selector:
    app: mssql
  ports:
    - protocol: TCP
      port: 1433
      targetPort: 1433
  type: LoadBalancer
---
apiVersion: apps/v1beta1
kind: Deployment
metadata:
  name: mssql-deployment
spec:
  replicas: 1
  template:
    metadata:
      labels:
        app: mssql
    spec:
      terminationGracePeriodSeconds: 10
      containers:
      - name: mssql
        image: microsoft/mssql-server-linux
        ports:
        - containerPort: 1433
        env:
        - name: ACCEPT_EULA
          value: "Y"
        - name: SA_PASSWORD
          valueFrom:
            secretKeyRef:
              name: mssql
              key: SA_PASSWORD
        volumeMounts:
        - name: mssql-persistent-storage
          mountPath: /var/opt/mssql
      volumes:
      - name: mssql-persistent-storage
        persistentVolumeClaim:
          claimName: mssql-data-claim
```

## Test the connectivity
Get the ip address of the database

``` bash
sudo minikube service mssql-deployment --url
```

Install sqlcmd then
``` bash
/opt/mssql-tools/bin/sqlcmd -S <ip>,<port> -U SA -P '<sa_password>'
``` 
