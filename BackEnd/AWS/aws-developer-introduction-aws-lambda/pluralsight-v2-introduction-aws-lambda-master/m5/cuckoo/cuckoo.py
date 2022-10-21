import datetime
import boto3
from jinja2 import Template

# Start of some things you need to change
#
#
# Recipient emails or domains in the AWS Email Sandbox must be verified
# You'll want to change this to the email you verify in SES
FROM_ADDRESS = 'globomanticspetcare@gmail.com'
REPLY_TO_ADDRESS = 'globomanticspetcare@gmail.com'

CLIENTS = [
    {
        # You'll need to verify this email
        'email': 'f_mcorey@yahoo.com', 
        'first_name': 'Fernando',
        'last_name': 'Medina Corey',
        'pet_name': 'Riley'
    },
]

EMPLOYEES = [
    {
        # You'll need to verify this email
        'email': 'springfield.homer@yahoo.com',
        'first_name': 'Homer',
        'last_name': 'Simpson'
    },
]

# Change to the bucket you create on your AWS account
TEMPLATE_S3_BUCKET = 'gpc-email-templates'
#
#
# End of things you need to change

def get_template_from_s3(key):
    """Loads and returns html template from Amazon S3"""
    s3 = boto3.client('s3')
    s3_file = s3.get_object(
        Bucket=TEMPLATE_S3_BUCKET, 
        Key=key
    )
    try:
        template = Template(s3_file['Body'].read().decode('utf-8'))
    except Exception as e:
        print('Failed to load template')
        raise e
    return template

def render_come_to_work_template(employee_first_name):
    template = get_template_from_s3('come_to_work.html')
    html_email = template.render(first_name = employee_first_name)
    plaintext_email = 'Hello {0}, \nPlease remember to be into work by 8am'.format(employee_first_name)
    return html_email, plaintext_email

def render_daily_tasks_template():
    template = get_template_from_s3('daily_tasks.html')
    tasks = {
        'Monday': '- Clean the dog areas\n',
        'Tuesday': '- Clean the cat areas\n',
        'Wednesday': '- Feed the aligator\n',
        'Thursday': '- Clean the dog areas\n',
        'Friday': '- Clean the cat areas\n',
        'Saturday': '- Relax! Play with the puppies! It\'s the weekend!',
        'Sunday': '- Relax! Play with the puppies! It\'s the weekend!'
    }
    # Gets an integer value from 0 to 6 for today (Monday - Sunday)
    # Keep in mind this will run in GMT and you will need to adjust runtimes accordingly 
    days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']
    today = days[datetime.date.today().weekday()]
    html_email = template.render(
        day_of_week=today, 
        daily_tasks=tasks[today]
    )
    plaintext_email = (
        "Remember to do all of these today:\n"
        "- Feed the dogs\n"
        "- Feed the rabbits\n"
        "- Feed the cats\n"
        "- Feed the turtles\n"
        "- Walk the dogs\n"
        "- Empty cat litterboxes\n"
        "{0}".format(tasks[today])
    )
    return html_email, plaintext_email

def render_pickup_template(client_first_name, client_pet_name):
    template = get_template_from_s3('pickup.html')
    html_email = template.render(
        first_name=client_first_name, 
        pet_name = client_pet_name
    )
    plaintext_email = (
        'Hello {0}, \nPlease remember to '
        'pickup {1} by 7pm!'.format(
            client_first_name, 
            client_pet_name
        )
    )
    return html_email, plaintext_email

def send_email(html_email, plaintext_email, subject, recipients):
    try:
        ses = boto3.client('ses')
        response = ses.send_email(
            Source=FROM_ADDRESS,
            Destination={
                'ToAddresses': [recipients],
                'CcAddresses': [],
                'BccAddresses': []
            },
            Message={
                'Subject': {
                    'Data': subject,
                },
                'Body': {
                    'Text': {
                        'Data': plaintext_email
                    },
                    'Html': {
                        'Data': html_email
                    }
                }
            },
            ReplyToAddresses=[
                REPLY_TO_ADDRESS,
            ]
        )
    except Exception as e:
        print('Failed to send message via SES')
        print(e)
        raise e

def handler(event,context):
    event_trigger = event['resources'][0]
    print('event triggered by ' + event_trigger)
    if 'come_to_work' in event_trigger:
        for employee in EMPLOYEES:
            html_email, plaintext_email = render_come_to_work_template(employee['first_name'])
            send_email(html_email, plaintext_email, 'Work Schedule Reminder', employee['email'])
    elif 'daily_tasks' in event_trigger:
        for employee in EMPLOYEES:
            html_email, plaintext_email = render_daily_tasks_template()
            send_email(html_email, plaintext_email, 'Daily Tasks Reminder', employee['email'])
    elif 'pickup' in event_trigger:
        for client in CLIENTS:
            html_email, plaintext_email = render_pickup_template(client['first_name'], client['pet_name'])
            send_email(html_email, plaintext_email, 'Pickup Reminder', client['email'])
    else:
        return 'No template for this trigger!'
