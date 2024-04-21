#!/bin/bash

set -eu

aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 127275507218.dkr.ecr.us-east-1.amazonaws.com

docker images

docker tag contosouniversity:latest 127275507218.dkr.ecr.us-east-1.amazonaws.com/contosouniversity:latest

docker push 127275507218.dkr.ecr.us-east-1.amazonaws.com/contosouniversity:latest