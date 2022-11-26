import React, {useState} from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Authentication from '../Screens/Authentication/Authentication';
import Home from '../Screens/Home/Home';
import Card from '../Screens/Card/Card';

const Stack = createNativeStackNavigator();
const Tab = createBottomTabNavigator();

export default function AppNavigation({ AppState }) {
    return (
        <NavigationContainer>
            <Stack.Navigator>
                <Stack.Screen
                    name="Authentication"
                    component={Authentication}
                    options={{
                        header: () => null
                    }}
                />
                <Stack.Screen name="Home">
                    {(props) => <Home {...props} AppState={AppState} />}
                </Stack.Screen>
                {/* <Stack.Screen
                    name="Home"
                    component={Home}
                    options={{
                        header: () => null
                    }}
                /> */}
                <Stack.Screen
                    name="Card"
                    component={Card}
                    options={{
                        header: () => null
                    }}
                />
            </Stack.Navigator>
        </NavigationContainer>
    );
}


