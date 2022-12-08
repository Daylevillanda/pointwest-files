import React, { useState, useEffect } from "react";
import { StyleSheet, SafeAreaView, Alert, TouchableHighlight } from "react-native"
import { Button, Text } from '@rneui/themed';
import * as LocalAuthentication from 'expo-local-authentication'
import { onPress } from "deprecated-react-native-prop-types/DeprecatedTextPropTypes";

export default function FingerPrintScreen({ navigation }) {

    const fallbackToDefaultAuth = () => {
        console.log('Get password');
    }

    const AlertComponent = (title, message, buttonText, buttonFunction) => {
        return Alert.alert(title, message, [
            {
                text: buttonText,
                onPress: buttonFunction
            }
        ]);
    };

    const handleBiometricAuth = async () => {
        const isBiometricAvailable = await LocalAuthentication.hasHardwareAsync();
        if (!isBiometricAvailable) {
            return AlertComponent(
                'Please Enter Password',
                'Biometric Auth Nnot supported',
                'Ok',
                () => fallbackToDefaultAuth()
            )
        }

        const savedBiometrics = await LocalAuthentication.isEnrolledAsync();
        if (!savedBiometrics) {
            return AlertComponent(
                'Biometrics not found',
                'Please login with password',
                'Ok',
                () => fallbackToDefaultAuth()
            )
        }

        const biometricAuth = await LocalAuthentication.authenticateAsync({
            promptMessage: 'Login with Biometrics',
            cancelLabel: 'Cancel',
            disableDeviceFallback: true
        });

        if (biometricAuth.success) {
            return AlertComponent(
                'Login Successful!',
                '',
                'Ok',
                () => fallbackToDefaultAuth()
            )
        }
    }

    return (
        <SafeAreaView style={styles.container}>
            <Button
                buttonStyle={styles.button}
                title="Back to Home"
                onPress={() => navigation.navigate("Home")}
            ></Button>
            <TouchableHighlight
                style={{
                    height: 60,
                    marginTop: 200
                }}>
                <Button
                    title='Login with Biometrics'
                    color='Black'
                    onPress={handleBiometricAuth}>
                </Button>
            </TouchableHighlight>
        </SafeAreaView>
    );
}

const styles = StyleSheet.create({
    container: {
        height: '100%',
        backgroundColor: 'black',
        padding: 20,
        flexDirection: 'column',
        justifyContent: 'space-between',
        marginTop: 10,
    }, button: {
        margin: 10,
    }
});