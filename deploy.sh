if [ $1 == 'up' ]
then
    gcloud config set project PROJECT_ID
    gcloud config set compute/zone us-central1-a
    gcloud container clusters create finances-api-cluster --num-nodes=3
    kubectl create deployment finances-api --image=gleisonbs/finances-api
    kubectl expose deployment finances-api --type=LoadBalancer --port 80 --target-port 5000
    while [ "$(kubectl get service finances-api -o json | jq '.status.loadBalancer.ingress[0].ip')" == null ]
    do
        sleep 5
    done
    echo $(kubectl get service finances-api -o json | jq '.status.loadBalancer.ingress[0].ip')
elif [ $1 == 'down' ]
then
    kubectl delete service finances-api
    kubectl delete deployment finances-api
    gcloud container clusters delete finances-api-cluster --quiet
else
    echo "Unknown command"
    echo "usage: ./deploy command"
    echo "command: "
    echo "  up        deploys the container"
    echo "  down      cleans everything"
fi