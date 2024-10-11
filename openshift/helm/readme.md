proxy.istio.io/config: '{ "holdApplicationUntilProxyStarts": true }'

istio Failed to watch Kube API server

curl https://$KUBERNETES_SERVICE_HOST:$KUBERNETES_SERVICE_PORT/api/v1/namespaces/default/pods


10.217.4.1

apiVersion: networking.istio.io/v1beta1
kind: ServiceEntry
metadata:
  name: k8s-api-ext
  namespace: istio-system 
spec:
  hosts:
    - kubernetes.default.svc.cluster.local
  addresses:
    - 172.21.0.1
  endpoints:
    - address: 172.21.0.1
  exportTo:
    - "*"
  location: MESH_EXTERNAL
  resolution: STATIC
  ports:
    - number: 443
      name: https-k8s
      protocol: HTTPS


apiVersion: networking.istio.io/v1alpha3
kind: DestinationRule
metadata:
  name: k8s-default-destrule
  namespace: robotorium-idm
spec:
  host: "kubernetes.default.svc" #Disabling it for Kube API Server communication
  trafficPolicy:
    tls:
      mode: DISABLE      

curl -kv https://kubernetes.default:443      

10.217.4.1:443


apiVersion: networking.istio.io/v1beta1
kind: ServiceEntry
metadata:
  name: k8s-api-ext
  namespace: robotorium-idm
spec:
  hosts:
    - kubernetes.default.svc.cluster.local
  addresses:
    - 10.217.4.1
  endpoints:
    - address: 10.217.4.1
  exportTo:
    - "*"
  location: MESH_EXTERNAL
  resolution: STATIC
  ports:
    - number: 443
      name: https-k8s
      protocol: HTTPS



apiVersion: networking.istio.io/v1beta1
kind: Sidecar
metadata:
  name: default
  namespace: robotorium-servicemesh  # or just place here your container NS
spec:  # also consider using a workloadSelector to fine tune your K8s API permissions to a specific pod
  egress:
    - hosts:
        - ./*
        - default/kubernetes.default.svc.cluster.local
        - default/etcd.default.svc.cluster.local
        - robotorium-servicemesh/*