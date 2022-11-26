import { StatusBar } from 'expo-status-bar';
import { Pressable, StyleSheet, Text, View } from 'react-native';

export default function Card({navigation}) {
  const onPressHandler = () => {
    navigation.goBack()
  }

  return (
    <View style={styles.container}>
      <Text>This is Card</Text>
      <StatusBar style="auto" />
      <Pressable
        onPress={onPressHandler}
      >
        <Text>Go back home</Text>
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
