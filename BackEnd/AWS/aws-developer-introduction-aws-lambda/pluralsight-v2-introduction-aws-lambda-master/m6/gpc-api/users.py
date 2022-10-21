import boto3
import json

dynamodb = boto3.resource('dynamodb')
table = dynamodb.Table('users')


def create_user(email, data):
    item = {
        "email": email,
        "data": data
    }
    result = table.put_item(
        Item=item
    )
    status_code = result['ResponseMetadata']['HTTPStatusCode']
    if status_code == 200:
        response = {
            "statusCode": 200,
            "headers": {"Access-Control-Allow-Origin": "*"},
            "body": json.dumps(item)
        }
        return response
    else:
        return {
            "statusCode": 400,
            "headers": {"Access-Control-Allow-Origin": "*"},
            "body": json.dumps({"status": "request invalid"})
        }
