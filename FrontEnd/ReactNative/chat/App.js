import React, { useState } from 'react';
import { FlatList, StyleSheet, Text, View, StatusBar, Pressable, TextInput } from 'react-native';

const styles = StyleSheet.create({
  container: {
   flex: 1,
   marginTop: StatusBar.currentHeight || 0,
  },
  item: {
    padding: 10,
    fontSize: 18,
    height: 44,
  },
  button: {
    justifyContent: 'center',
    alignItems: 'center',
    width: 50,
    height: 50,
    backgroundColor: 'gray'
  }
});

export default function App() {
  const [text, setText] = useState('');
  const [data, setData] = useState([
    {
      text: 'Hello developer',
      createdAt: new Date(),
      user: {
        _id: 1,
        name: 'React Native',
        avatar: 'https://placeimg.com/140/140/any',
      },
    },
    {
      text: 'Can you help me?',
      createdAt: new Date(),
      user: {
        _id: 2,
        name: 'React Native',
        avatar: 'https://placeimg.com/140/140/any',
      },
    },
    {
      text: 'How can i help?',
      createdAt: new Date(),
      user: {
        _id: 1,
        name: 'React Native',
        avatar: 'https://placeimg.com/140/140/any',
      },
    }
  ])
  return (
    <View style={styles.container}>
      <FlatList
        keyExtractor={(item, index) => index.toString()}
        data={data}
        renderItem={
          ({item}) => 
          <Text style={[styles.item, item.user._id === 2 && {alignSelf:'flex-end'}]}>{item.text}</Text>
        }
      />
      <TextInput
        style={{height: 40}}
        placeholder="Type here"
        onChangeText={newText => setText(newText)}
        defaultValue={text}
      />
      <Pressable style={styles.button} onPress={()=>{
        setData(arr => [...data, 
          {
            text: text,
            createdAt: new Date(),
            user: {
              _id: 2,
              name: 'React Native',
              avatar: 'https://placeimg.com/140/140/any',
            },
          }]
        )
        setText('')
      }}>
        <Text>Send</Text>
      </Pressable>
    </View>
  );
}


// import { StyleSheet, Text, View } from 'react-native';
// import React, { useState, useCallback, useEffect } from 'react'
// import { GiftedChat, Bubble } from 'react-native-gifted-chat'

// export default function App() {
//   const [messages, setMessages] = useState([]);

//   useEffect(() => {
//     setMessages([
//       {
//         _id: 1,
//         text: 'Hello developer',
//         createdAt: new Date(),
//         user: {
//           _id: 2,
//           name: 'React Native',
//           avatar: 'https://placeimg.com/140/140/any',
//         },
//       },
//       {
//         _id: 2,
//         text: 'Some text',
//         createdAt: new Date(),
//         user: {
//           _id: 1
//         },
//       }
//     ])
//   }, [])

//   const onSend = useCallback((messages = []) => {
//     setMessages(previousMessages => GiftedChat.append(previousMessages, messages))
//   }, [])
//   const renderBubble= props => {
//     return (
//       <Bubble
//         {...props}
//         textStyle={{
//           left: {
//             color: '#FFFFFF'
//           },
//           right: {
//             color: '#000000',
//           },
//         }}
//         wrapperStyle={{
//           left: {
//             backgroundColor: '#5E5CE6'
//           },
//           right: {
//             backgroundColor: '#FFFFFF',
//           }
//         }}
//         // containerStyle={{
//         //   left: {
//         //     height: 300
//         //   }
//         // }}
//       />
//     );
//   }
//   return (
//     <GiftedChat
//       messages={messages}
//       renderBubble={renderBubble}
//       onSend={messages => onSend(messages)}
//       user={{
//         _id: 1,
//       }}
//     />
//   )
// }
