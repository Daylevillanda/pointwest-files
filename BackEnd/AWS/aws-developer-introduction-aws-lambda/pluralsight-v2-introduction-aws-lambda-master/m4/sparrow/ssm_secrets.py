import boto3


def get_secret(parameter_name):
    """Get a parameter from SSM Parameter store and decrypt it"""
    ssm = boto3.client('ssm')
    parameter = ssm.get_parameter(
        Name=parameter_name,
        WithDecryption=True
    )['Parameter']['Value']
    return parameter


def put_secret(parameter_name, parameter_value):
    """Put a parameter inside SSM Parameter store with encryption"""
    print('Putting a parameter with name of ' + parameter_name + ' into SSM.')
    ssm = boto3.client('ssm')
    ssm.put_parameter(
        Name=parameter_name,
        Value=parameter_value,
        Type='SecureString',
        Overwrite=True
    )
    print("Successfully added a parameter with the name of: " + parameter_name)

# Example of using put_secret() to add your keys
# SECRETS = {
#     "CONSUMER_KEY": "REPLACE_ME",
#     "CONSUMER_SECRET": "REPLACE_ME",
#     "ACCESS_TOKEN_KEY": "REPLACE_ME",
#     "ACCESS_TOKEN_SECRET": "REPLACE_ME"
# }
# for parameter_name, parameter_value in SECRETS.items():
#     put_secret(parameter_name, parameter_value)
