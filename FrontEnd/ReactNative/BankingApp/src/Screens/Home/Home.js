import { StatusBar } from 'expo-status-bar';
import { Pressable, StyleSheet, Text, View } from 'react-native';

export default function Home({navigation, AppState}) {
  const { isHungry, setIsHungry } = AppState
  console.log(isHungry)
  return (
    <View style={styles.container}>
      <Text>This is Home</Text>
      <StatusBar style="auto" />
      <Pressable
        onPress={()=>navigation.replace('Authentication')}
      >
        <Text>Go to Authentication</Text>
      </Pressable>
      <Pressable
        onPress={()=>navigation.navigate('Card')}
      >
        <Text>Go to Card</Text>
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
});
