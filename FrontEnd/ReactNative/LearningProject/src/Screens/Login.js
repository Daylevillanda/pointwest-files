import React, {useState} from 'react';
import { StatusBar } from 'expo-status-bar';
import { Pressable, StyleSheet, Text, View, TextInput } from 'react-native';

export default function Login({appState}) {
  const { isLoggedIn, setisLoggedIn } = appState
  const [input, setInput] = useState('')

  const submit = (inputText) => {
    setTimeout(()=>{
      if(inputText !== '1234'){
        alert('wrong password')
        return setInput('')
      }
      setisLoggedIn(true)
    }, 1000)
  }

  return (
    <View style={styles.container}>
      <Text>Login</Text>
      <StatusBar style="auto"/>
      <TextInput
      keyboardType='number-pad'
        style={{height: 40, textAlign:'center'}}
        placeholder="1234"
        onChangeText={input => {
          setInput(input)
          input.length == 4? submit(input):''
        }}
        secureTextEntry
        defaultValue={input}
        maxLength={4}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
