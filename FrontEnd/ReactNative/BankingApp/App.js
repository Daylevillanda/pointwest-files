import AppNavigation from './src/AppNavigation/main'
import AppState from './src/AppState/main'

export default function App() {
  return <AppNavigation AppState={AppState()}/>
}

