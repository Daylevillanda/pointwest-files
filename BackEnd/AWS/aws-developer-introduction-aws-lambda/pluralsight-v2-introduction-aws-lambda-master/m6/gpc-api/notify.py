import boto3

ses = boto3.client('ses')

# Make sure to verify these emails in SES first
FROM_ADDRESS = 'globomanticspetcare@gmail.com'
REPLY_TO_ADDRESS = FROM_ADDRESS
ADMIN_ADDRESS = 'f_mcorey@yahoo.com'


def notify_admin_of_new_client(email):
    message = (
        'A new client has been added with the ' +
        ' email of: ' + email
    )
    ses.send_email(
        Source=FROM_ADDRESS,
        Destination={
            'ToAddresses': [ADMIN_ADDRESS],
            'CcAddresses': [],
            'BccAddresses': []
        },
        Message={
            'Subject': {
                'Data': 'A new client has been added!',
            },
            'Body': {
                'Text': {
                    'Data': message
                }
            }
        },
        ReplyToAddresses=[
            REPLY_TO_ADDRESS,
        ]
    )
