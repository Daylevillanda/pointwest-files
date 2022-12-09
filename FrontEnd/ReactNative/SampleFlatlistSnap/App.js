// import { StyleSheet, View, FlatList, Dimensions } from "react-native";
// import { useState } from "react";
// import GeeksforGeeks from "./GeeksforGeeks";
  
// export default function App() {
//     const [items, setItems] = useState([
//         {
//             id: "1",
//             name: "GeeksforGeeks View 1",
//         },
//         {
//             id: "2",
//             name: "GeeksforGeeks View 2",
//         },
//         {
//             id: "3",
//             name: "GeeksforGeeks View 3",
//         },
//         {
//             id: "4",
//             name: "GeeksforGeeks View 4",
//         },
//         {
//             id: "5",
//             name: "GeeksforGeeks View 5",
//         },
//         {
//             id: "6",
//             name: "GeeksforGeeks View 6",
//         },
//         {
//             id: "7",
//             name: "GeeksforGeeks View 7",
//         },
//   ]);
    
//     return (
//         <View>
//             <FlatList
//                 data={items}
//                 renderItem={({ item }) => <GeeksforGeeks name={item.name} />}
//                 keyExtractor={(item) => item.id}
//                 snapToAlignment="start"
//                 decelerationRate={"fast"}
//                 snapToInterval={Dimensions.get("window").width}
//                 horizontal
//             />
//         </View>
//   );
// }
  
// const styles = StyleSheet.create({
//     container: {
//         flex: 1,
//         backgroundColor: "#fff",
//         alignItems: "center",
//         justifyContent: "center",
//     },
// });




// import * as React from 'react';
// import {
//   Animated,
//   Dimensions,
//   Image,
//   FlatList,
//   Text,
//   View,
//   StyleSheet,
// } from 'react-native';
// import { StatusBar } from 'expo-status-bar';

// const { width, height } = Dimensions.get('screen');
// const ITEM_WIDTH = width * 0.76;
// const ITEM_HEIGHT = ITEM_WIDTH * 1.47;

// const images = [
//   'https://images.unsplash.com/photo-1551316679-9c6ae9dec224?w=800&q=80',
//   'https://images.unsplash.com/photo-1562569633-622303bafef5?w=800&q=80',
//   'https://images.unsplash.com/photo-1503656142023-618e7d1f435a?w=800&q=80',
//   'https://images.unsplash.com/photo-1555096462-c1c5eb4e4d64?w=800&q=80',
//   'https://images.unsplash.com/photo-1517957754642-2870518e16f8?w=800&q=80',
//   'https://images.unsplash.com/photo-1546484959-f9a381d1330d?w=800&q=80',
//   'https://images.unsplash.com/photo-1548761208-b7896a6ff225?w=800&q=80',
//   'https://images.unsplash.com/photo-1511208687438-2c5a5abb810c?w=800&q=80',
//   'https://images.unsplash.com/photo-1548614606-52b4451f994b?w=800&q=80',
//   'https://images.unsplash.com/photo-1548600916-dc8492f8e845?w=800&q=80',
// ];
// const data = images.map((image, index) => ({
//   key: String(index),
//   photo: image,
//   avatar_url: `https://randomuser.me/api/portraits/women/${Math.floor(
//     Math.random() * 40
//   )}.jpg`,
// }));

// export default function App() {
//   return (
//     <View style={styles.container}>
//       <StatusBar hidden />
//       <Text style={{ fontSize: 114 }}>❤️</Text>
//       <Text
//         style={{
//           // fontFamily: 'Menlo',
//           marginTop: 10,
//           fontWeight: '800',
//           fontSize: 32,
//         }}
//       >
//         Expo
//       </Text>
//       <Text style={{ 
//         // fontFamily: 'Menlo', 
//         fontStyle: 'italic', fontSize: 18 }}>
//         (expo.io)
//       </Text>
//     </View>
//   );
// }

// const styles = StyleSheet.create({
//   container: {
//     flex: 1,
//     backgroundColor: '#fff',
//     alignItems: 'center',
//     justifyContent: 'center',
//   },
// });





import { Entypo, Feather } from '@expo/vector-icons';
import React, {useEffect, useRef, useState} from 'react';
import { Dimensions, FlatList, Text, TouchableOpacity, View } from 'react-native';

const { width, height } = Dimensions.get('screen');
const data = [{
  key: "1",
  job: "GeeksforGeeks View 1",
},
{
  key: "2",
  job: "GeeksforGeeks View 2",
},
{
  key: "3",
  job: "GeeksforGeeks View 3",
},
{
  key: "4",
  job: "GeeksforGeeks View 4",
}]

const _colors = {
  active: `#FCD259ff`,
  inactive: `#FCD25900`,
};
const _spacing = 10;

export default function App() {
  const [index, setIndex] = useState(0)
  const [viewPosition, setViewPosition] = useState(0)
  const ref = useRef(null);
  useEffect(()=>{
    ref.current.scrollToIndex({
      index,
      animated: true,
      viewPosition,
      // viewOffset: viewPosition === 0.5 || viewPosition === 1? 0: _spacing,
      viewOffset: viewPosition === 0.5 || viewPosition === 1? 0: _spacing,
    })
  },[index, viewPosition])
  
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <FlatList
        ref={ref}
        initialScrollIndex = {index}
        style={{ flexGrow: 0, 
          // paddingLeft:index === 0? (width-200)/2: 0 
        }}
        data={data}
        keyExtractor={(item) => item.key}
        contentContainerStyle={{ paddingLeft: _spacing }}
        showsHorizontalScrollIndicator={false}
        horizontal
        renderItem={({ item, index: fIndex }) => {
          return (
            <TouchableOpacity onPress={() => {
              setIndex(fIndex)
            }}>
              <View
                style={{
                  marginRight: _spacing,
                  padding: _spacing,
                  borderWidth: 2,
                  borderColor: _colors.active,
                  borderRadius: 12,
                  backgroundColor: fIndex === index? _colors.active: _colors.inactive,
                  width: 200
                }}>
                <Text style={{ color: '#36303F', fontWeight: '700' }}>
                  {item.job}
                </Text>
              </View>
            </TouchableOpacity>
          );
        }}
      />
      <View
        style={{
          alignItems: 'center',
          flexDirection: 'row',
          marginTop: _spacing * 10,
        }}>
        <View style={{ alignItems: 'center' }}>
          <Text
            style={{
              color: '#36303F',
              fontWeight: '700',
              marginBottom: _spacing,
            }}>
            Scroll position
          </Text>
          <View
            style={{
              flexDirection: 'row',
              width: width / 2,
              justifyContent: 'center',
            }}>
            <TouchableOpacity onPress={() => {
              setViewPosition(0)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                  marginRight: _spacing,
                }}>
                <Entypo name='align-left' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => {
              setViewPosition(0.5)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                  marginRight: _spacing,
                }}>
                <Entypo
                  name='align-horizontal-middle'
                  size={24}
                  color='#36303F'
                />
              </View>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => {
              setViewPosition(1)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                }}>
                <Entypo name='align-right' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
          </View>
        </View>
        <View style={{ alignItems: 'center' }}>
          <Text
            style={{ color: '#36303F', fontWeight: '700', marginBottom: 10 }}>
            Navigation
          </Text>
          <View
            style={{
              flexDirection: 'row',
              width: width / 2,
              justifyContent: 'center',
            }}>
            <TouchableOpacity onPress={() => {
              if (index === 0 ){
                return;
              }
              setIndex(index - 1)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                  marginRight: _spacing,
                }}>
                <Feather name='arrow-left' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => {
              if (index === data.length -1 ){
                return;
              }
              setIndex(index + 1)
            }}>
              <View
                style={{
                  padding: _spacing,
                  backgroundColor: '#FCD259',
                  borderRadius: _spacing,
                }}>
                <Feather name='arrow-right' size={24} color='#36303F' />
              </View>
            </TouchableOpacity>
          </View>
        </View>
      </View>
    </View>
  );
}