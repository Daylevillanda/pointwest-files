import { StatusBar } from 'expo-status-bar';
import { Pressable, StyleSheet, Text, View } from 'react-native';

export default function Authentication({navigation, appState}) {
  const { isHungry, setIsHungry } = appState
  console.log(isHungry)
  const onPressHandler = () => {
    navigation.replace('Home')
  }

  return (
    <View style={styles.container}>
      <Text>This is Authentication</Text>
      <StatusBar style="auto" />
      {/* <StatusBar style="light || dark" /> */}
      <Pressable
        onPress={onPressHandler}
      >
        <Text>Go to Home</Text>
      </Pressable>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: 'white',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
