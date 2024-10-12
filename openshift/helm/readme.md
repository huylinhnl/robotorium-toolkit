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
  namespace: istio-system 
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




apiVersion: networking.istio.io/v1alpha3
kind: Gateway
metadata:
  name: service-mesh-demo-gateway
  namespace: robotorium-servicemesh
spec:
  selector:
    istio: ingressgateway # use istio default controller
  servers:
  - port:
      number: 80
      name: http
      protocol: HTTP
    hosts:
    - "*" 


apiVersion: networking.istio.io/v1alpha3
kind: VirtualService
metadata:
  name: virtual-service-orders
  namespace: robotorium-servicemesh
spec:
  hosts:
  - "*"
  gateways:
  - service-mesh-demo-gateway ###############################################
  http:                       # This Virtual Service listens for requests
  - match:                    # coming in on this Gateway, service-mesh-demo-gateway
    - uri:                    ###############################################
        exact: /     ###############################################
    route:           # Any root request, for example, a request coming from:
    - destination:   # http://istio-ingressgateway-istio-system.apps.mydomain.eastus.aroapp.io/
        host: robo-toolkit # will be forwarded to the Kubernetes service named orders at port 8080
        port:        ###############################################
          number: 8888           



curl --location --request POST 'http://istio-ingressgateway-robotorium-servicemesh.apps-crc.testing/' \
--header 'Content-Type: application/json' \
--data-raw '{
  "customer": {
    "id": 3,
    "firstName": "Barney",
    "lastName": "Kelly",
    "email": "Barney.Kelly@gmail.com"
  },
  "product": {
    "id": 2,
    "category": "Food",
    "description": "Blue Olives",
    "price": 39.99
  },
  "creditCard": {
    "number": "6767-8196-4877-7940-326",
    "expirationDate": "2023-09-08T01:14:59.686Z",
    "cvv": "851",
    "cardHolder": {
      "id": 3,
      "firstName": "Barney",
      "lastName": "Kelly",
      "email": "Barney.Kelly@gmail.com"
    }
  },
  "purchaseDate": 1669844628249
}'          




apiVersion: networking.istio.io/v1alpha3
kind: Gateway
metadata:
  name: robo-toolkit-gateway
  namespace: istio-system
spec:
  selector:
    istio: ingressgateway # use istio default controller
  servers:
  - port:
      number: 80
      name: http
      protocol: HTTP
    hosts:
    - "*"

apiVersion: security.istio.io/v1beta1
kind: AuthorizationPolicy
metadata: 
  name: allow-robo-toolkit 
  namespace: robotorium-idm
spec: 
  action: ALLOW
  rules:
   - to:
      - operation:
         paths:
           - /*
  selector:
     matchLabels: 
        app: robo-toolkit


apiVersion: security.istio.io/v1beta1
kind: AuthorizationPolicy
metadata: 
  name: allow-robo-toolkit
  namespace: robotorium-idm
spec: 
  action: ALLOW
  rules:
   - to:
      - operation:
         paths:
           - /*
  selector:
     matchLabels: 
       app: robo-toolkit        