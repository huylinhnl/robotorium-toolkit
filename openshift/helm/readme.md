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

       https://10.217.4.1/.well-known/oauth-authorization-server



https://oauth-openshift.apps-crc.testing/login?then=%2Foauth%2Fauthorize%3Fapproval_prompt%3Dforce%26client_id%3Dsystem%253Aserviceaccount%253Arobotorium-idm%253Arobo-toolkit%26redirect_uri%3Dhttps%253A%252F%252Frobo-toolkit-istio-system.apps-crc.testing%252Foauth%252Fcallback%26response_type%3Dcode%26scope%3Duser%253Ainfo%2Buser%253Acheck-access%26state%3Dccd11719182fe4496de61ca6240f9029%253A%252F       

 10.217.0.87:39074->192.168.127.2:443


 tcp 10.217.0.109:37202->10.217.4.156:8080: read: connection reset by peer


oc apply https://raw.githubusercontent.com/Maistra/istio/maistra-2.2/samples/bookinfo/platform/kube/bookinfo.yaml
oc -n robotorium-idm apply -f https://raw.githubusercontent.com/Maistra/istio/maistra-2.2/samples/bookinfo/networking/bookinfo-gateway.yaml



No resources found in istio-system namespace.

Huyli@thomasbui MINGW64 /c/git/robotorium/robotorium-toolkit/openshift/helm (feature/toolkit)
$ oc get AuthorizationPolicy
NAME            AGE
allow-ingress   3d6h
allow-nothing   3d1h

Name:         allow-ingress
Namespace:    istio-system
Labels:       <none>
Annotations:  <none>
API Version:  security.istio.io/v1
Kind:         AuthorizationPolicy

Spec:
  Action:  ALLOW
  Rules:
    To:
      Operation:
        Paths:
          /*
  Selector:
    Match Labels:
      App:  istio-ingressgateway


apiVersion: security.istio.io/v1
kind: AuthorizationPolicy
metadata:
  name: allow-ingress
  namespace: istio-system
spec:
  action: ALLOW
  rules:
  - to:
    - operation:
        paths:
        - /*
  selector:
    matchLabels:
      app: istio-ingressgateway      

 curl -kv http://robotorium-idm-bookinfo-gateway-684888c0ebb17f37-istio-system.apps-crc.testing -H "Authorization: Bearer 1111"     




curl -v  http://robotorium-idm-bookinfo-gateway-684888c0ebb17f37-istio-system.apps-crc.testing -H "Authorization: Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6InlEQWdDV0h2aWc0b2t0cGZjcnB0OGFwNV9hNWluYnVhbUZvamVGbV9XaUkifQ.eyJhdWQiOlsiaHR0cHM6Ly9rdWJlcm5ldGVzLmRlZmF1bHQuc3ZjIl0sImV4cCI6MTcyODkzODIzMSwiaWF0IjoxNzI4OTM0NjMxLCJpc3MiOiJodHRwczovL2t1YmVybmV0ZXMuZGVmYXVsdC5zdmMiLCJqdGkiOiI0NzEzZDcyOS05ZmUwLTQ0YzAtYTZmMS0xYWMxZmM2YzM2MjUiLCJrdWJlcm5ldGVzLmlvIjp7Im5hbWVzcGFjZSI6InJvYm90b3JpdW0taWRtIiwic2VydmljZWFjY291bnQiOnsibmFtZSI6ImJvb2tpbmZvLXByb2R1Y3RwYWdlIiwidWlkIjoiYTYwNzJiMjctOWFmNC00NGMzLThhYTItM2YxZTAxOGI1M2YwIn19LCJuYmYiOjE3Mjg5MzQ2MzEsInN1YiI6InN5c3RlbTpzZXJ2aWNlYWNjb3VudDpyb2JvdG9yaXVtLWlkbTpib29raW5mby1wcm9kdWN0cGFnZSJ9.n6kAG17S3CIk3QET_fZ7N0GVFsFHSovtLhLeweBBEBuVe6jsrwFlb8EgdWEfjNk-qaHhkVmcxEBxAbpdYaco6JTBQXJbqGDgWuBft_s39nHs5SrjIxJ-M45_7xLZUzJSAij2HiMR0_6DJFXeAmJjbNSScGawFCyNYmCYO9nirHL-Ej099Bkq95N7fmUmBJyfS8P95hdJ0B2Ut3SD4B8Vzi1iweI9tUJUQwnzX6wVyAfzZa_NlF9v22C5DEePNH3uLM8023Tc-RtUQCtMJe2zPNIzPvD-WAzoUoCRtd32Vzq9sEYtEZI5v_R6F-VugiOgjto5hqyxQ0nPUP7NfmJ_1jzP88MjXC7nyIdGpY7cbOWXZ6ZarB4EYWS2EHGqdVmug-aRAsNvBttomPEm2ivejcYv7QlpTjqWGWK2O4jlUq8jpXfvRyGHAx0B48NaTTtosIQvbDIBMEKl5PKCJ1ryiB98QdddcUhqcD_-n_WObxZlZAX6cSKQIqzPC9SIwJidDTTem9-JMpXLysGtTA49biClYwma4z443bALn3cHIWYLUoYfSdRQLrFekvrzMQNRVxRTQExTYb547G1iGP5kFPn5n4bCYoYBQStijzi44cb5srKcdPE8X_WF2JGll3qNbFYtIeVV6uUF1ttTZRh6WoQCaR5dzgLe1OoG1Tgk-hE"

 TOKEN=$(oc -n robotorium-idm get secret $(oc -n robotorium-idm get sa robo-toolkit -o jsonpath='{.secrets[0].name}') -o jsonpath='{.data.token}' | base64 --decode)

 oc sa get-token -n robotorium-idm robo-toolkit


 curl -kv http://robotorium-idm-bookinfo-gateway-684888c0ebb17f37-istio-system.apps-crc.testing  --header "Authorization: Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6InlEQWdDV0h2aWc0b2t0cGZjcnB0OGFwNV9hNWluYnVhbUZvamVGbV9XaUkifQ.eyJhdWQiOlsiaHR0cHM6Ly9rdWJlcm5ldGVzLmRlZmF1bHQuc3ZjIl0sImV4cCI6MTcyODkzODIzMSwiaWF0IjoxNzI4OTM0NjMxLCJpc3MiOiJodHRwczovL2t1YmVybmV0ZXMuZGVmYXVsdC5zdmMiLCJqdGkiOiI0NzEzZDcyOS05ZmUwLTQ0YzAtYTZmMS0xYWMxZmM2YzM2MjUiLCJrdWJlcm5ldGVzLmlvIjp7Im5hbWVzcGFjZSI6InJvYm90b3JpdW0taWRtIiwic2VydmljZWFjY291bnQiOnsibmFtZSI6ImJvb2tpbmZvLXByb2R1Y3RwYWdlIiwidWlkIjoiYTYwNzJiMjctOWFmNC00NGMzLThhYTItM2YxZTAxOGI1M2YwIn19LCJuYmYiOjE3Mjg5MzQ2MzEsInN1YiI6InN5c3RlbTpzZXJ2aWNlYWNjb3VudDpyb2JvdG9yaXVtLWlkbTpib29raW5mby1wcm9kdWN0cGFnZSJ9.n6kAG17S3CIk3QET_fZ7N0GVFsFHSovtLhLeweBBEBuVe6jsrwFlb8EgdWEfjNk-qaHhkVmcxEBxAbpdYaco6JTBQXJbqGDgWuBft_s39nHs5SrjIxJ-M45_7xLZUzJSAij2HiMR0_6DJFXeAmJjbNSScGawFCyNYmCYO9nirHL-Ej099Bkq95N7fmUmBJyfS8P95hdJ0B2Ut3SD4B8Vzi1iweI9tUJUQwnzX6wVyAfzZa_NlF9v22C5DEePNH3uLM8023Tc-RtUQCtMJe2zPNIzPvD-WAzoUoCRtd32Vzq9sEYtEZI5v_R6F-VugiOgjto5hqyxQ0nPUP7NfmJ_1jzP88MjXC7nyIdGpY7cbOWXZ6ZarB4EYWS2EHGqdVmug-aRAsNvBttomPEm2ivejcYv7QlpTjqWGWK2O4jlUq8jpXfvRyGHAx0B48NaTTtosIQvbDIBMEKl5PKCJ1ryiB98QdddcUhqcD_-n_WObxZlZAX6cSKQIqzPC9SIwJidDTTem9-JMpXLysGtTA49biClYwma4z443bALn3cHIWYLUoYfSdRQLrFekvrzMQNRVxRTQExTYb547G1iGP5kFPn5n4bCYoYBQStijzi44cb5srKcdPE8X_WF2JGll3qNbFYtIeVV6uUF1ttTZRh6WoQCaR5dzgLe1OoG1Tgk-hE" --header 'Content-Type: application/json' 


 https://oauth-openshift.apps-crc.testing/oauth/keys