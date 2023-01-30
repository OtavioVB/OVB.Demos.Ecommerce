#!/bin/bash
RED='\033[0;31m'
NC='\033[0m' 
GREEN='\033[0;32m'  
CYAN='\033[0;36m'  

echo -e "${GREEN} OVB.Demos.Ecommerce ${NC}Starting docker service"
echo -e "${GREEN} You must be logged in Sudo."
sudo service docker start

echo -e "${GREEN} OVB.Demos.Ecommerce ${NC}Starting Jaeger container..."
docker run --detach --hostname jaeger --name jaeger --publish 16686:16686 --env COLLECTOR_OTLP_ENABLED=true jaegertracing/all-in-one:latest  
echo -e "${GREEN} OVB.Demos.Ecommerce ${NC}Exporting ports and running..."

echo -e "${GREEN} OVB.Demos.Ecommerce ${NC}Starting Open Telemetry Collector container..."
docker run --detach --hostname otel-collector --name otel-collector --publish 4317:4317 --publish 4318:4318 -v $(pwd)/otel-collector-config.yaml:/etc/otel-collector-config.yaml  otel/opentelemetry-collector:latest --config=/etc/otel-collector-config.yaml
echo -e "${GREEN} OVB.Demos.Ecommerce ${NC}Exporting ports and running..."
echo -e "${GREEN} OK ${NC} All dependencies"