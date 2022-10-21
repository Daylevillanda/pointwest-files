#!/bin/bash
# This script only runs natively in Mac or Linux. Copy any below commands and paste into a
# command line for Windows machines.

# put an item into dynamodb from the command line
aws dynamodb put-item --table-name aws-developer --item "{\"id\":{\"S\":\"8934fdsfdas5\"},\"value\":{\"S\":\"Somehow I ended up in this shell script...\"}}"


# put an item into dynamodb with json file
aws dynamodb put-item --table-name aws-developer --item file://item.json
