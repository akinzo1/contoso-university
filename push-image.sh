#!/bin/bash

set -eu


docker tag contosouniversity:latest 127275507218.dkr.ecr.us-east-1.amazonaws.com/contosouniversity:latest

docker push 127275507218.dkr.ecr.us-east-1.amazonaws.com/contosouniversity:latest