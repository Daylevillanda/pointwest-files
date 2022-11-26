import { StatusBar } from 'expo-status-bar';
import { Pressable, StyleSheet, Text, View } from 'react-native';

import { GlobalStyle } from '../../Reusable/Styles/main'
import { useFonts, Poppins_600SemiBold } from '@expo-google-fonts/poppins';
export default function Authentication({navigation}) {
  const onPressHandler = () => {
    navigation.replace('Home')
  }
  let [fontsLoaded] = useFonts({
    Poppins_600SemiBold,
  });

  if (!fontsLoaded) {
    return null;
  }
  return (
    <View style={GlobalStyle.mainContainer}>
      <StatusBar style="dark" />
      <View style={[GlobalStyle.mainHeader, {alignSelf: 'center'}]}>
        <Text style={{fontFamily:'Poppins_600SemiBold', fontSize:20}}>Security screen</Text>
      </View>
    </View>
  );
}
