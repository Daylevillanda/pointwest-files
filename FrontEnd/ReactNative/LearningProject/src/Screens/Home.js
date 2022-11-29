import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';


const CustomButton = () => {

  return (
    <View>
      <Pressable
          onPress={()=>alert("Expense")}
          style={styles.button}
        >
          <LinearGradient
            // Button Linear Gradient
            start={{x: 0.0, y: 0.0}} end={{x: 1.0, y: 0.0}}
            locations={[0.0, 0.629]}
            colors={['#FF9F0A', '#FF375F']}
            useAngle={true}
            angle={45}
            angleCenter={{x:0.5, y:0.5}}
            style={styles.buttonLinearGradient}
          >
            <Text>Expense</Text>
          </LinearGradient>
      </Pressable>
    </View>
  )
}

export default function Login({appState}) {
  const { isLoggedIn, setisLoggedIn } = appState
  return (
    <View style={styles.container}>
      <Text>Home</Text>
      <StatusBar style="auto" />
      <CustomButton/>
      <Pressable
        onPress={()=>setisLoggedIn(false)}
      >
        <Text>Logout</Text>
      </Pressable>
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
  button: {
    width: 166,
    height: 44,
    borderRadius: 12
  },
  buttonLinearGradient: {
    flex: 1, 
    borderRadius: 12, 
    alignItems:'center', 
    justifyContent: 'center'
  }
});
