import json
from users import create_user
from notify import notify_admin_of_new_client


def handler(event, context):
    print(event)
    payload = json.loads(event['body'])
    client_email = payload['email']
    data = payload['data']
    response = create_user(client_email, data)
    if response["statusCode"] == 200:
        notify_admin_of_new_client(client_email)
    return response
