import React, {useState} from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";

import Home from "../Screens/Home";
import Login from "../Screens/Login";

const Stack = createNativeStackNavigator();

export default function AppNavigation({ AppState }) {
    return (
        <NavigationContainer>
            <Stack.Navigator>
                {AppState.isLoggedIn ? (
                    // Screens for logged in users
                    <Stack.Group screenOptions={{ headerShown: false }}>
                        <Stack.Screen name="HomeScreen">
                            {(props) => <Home {...props} appState={AppState} />}
                        </Stack.Screen>
                    </Stack.Group>
                ) : (
                    // Auth screens
                    <Stack.Group screenOptions={{ headerShown: false }}>
                        <Stack.Screen name="LoginScreen">
                            {(props) => <Login {...props} appState={AppState} />}
                        </Stack.Screen>
                    </Stack.Group>
                )}
                {/* Common modal screens */}
                {/* <Stack.Group screenOptions={{ presentation: 'modal' }}>
                    <Stack.Screen name="Help" component={Help} />
                    <Stack.Screen name="Invite" component={Invite} />
                </Stack.Group> */}
            </Stack.Navigator>
        </NavigationContainer>
    );
}


