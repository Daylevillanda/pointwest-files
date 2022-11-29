// import StartingPoint from './src/introduction/StartingPoint';

import AppNavigation from "./src/AppNavigation/AppNavigation";
import AppStateCustom from "./src/AppState/AppState";

export default function App() {
  return <AppNavigation AppState={AppStateCustom()}/>
}
