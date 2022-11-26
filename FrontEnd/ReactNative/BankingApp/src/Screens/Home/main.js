import { StatusBar } from 'expo-status-bar';
import { Pressable, StyleSheet, Text, View } from 'react-native';

export default function Home({navigation}) {
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
        // onPress={()=>setIsHungry(!isHungry)}
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
