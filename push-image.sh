#!/bin/bash

set -eu

docker login -u AWS -p $(aws ecr get-login-password --region us-east-1) 127275507218.dkr.ecr.us-east-1.amazonaws.com

docker tag contosouniversity:latest 127275507218.dkr.ecr.us-east-1.amazonaws.com/contosouniversity:latest

docker push 127275507218.dkr.ecr.us-east-1.amazonaws.com/contosouniversity:latest