mkcert "locpoc.dev" "*.locpoc.dev" 
kubectl create namespace locpoc
kubectl create secret tls -n locpoc locpoc-tls --cert=./locpoc.dev+1.pem  --key=./locpoc.dev+1-key.pem