import React, {useState} from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Authentication from '../Screens/Authentication/main';
import Home from '../Screens/Home/main';
import Card from '../Screens/Card/main';

const Stack = createNativeStackNavigator();
const Tab = createBottomTabNavigator();

export default function AppNavigation({ AppState }) {
    return (
        <NavigationContainer>
            <Stack.Navigator>
                <Stack.Screen name="Authentication" options={{header: () => null}}>
                    {(props) => <Authentication {...props} appState={AppState} />}
                </Stack.Screen>
                <Stack.Screen name="Home" options={{header: () => null}}>
                    {(props) => <Home {...props} appState={AppState} />}
                </Stack.Screen>
                <Stack.Screen name="Card">
                    {(props) => <Card {...props} appState={AppState} />}
                </Stack.Screen>
            </Stack.Navigator>
        </NavigationContainer>
    );
}


