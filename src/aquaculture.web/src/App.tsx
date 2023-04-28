import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import AuthPage from './pages/auth-page/auth-page';
import MeasurementsPage from './pages/measurements-page/measurements-page';
import MainPage from './pages/main-page/main-page';

function App() {
  return (
    <div className="App">
      <MainPage />
      {/* <BrowserRouter>
        <Routes>
          <Route path="/" element={<AuthPage />}/>
          <Route path="/tmp" element={<MeasurementsPage />}/>
          <Route path="/main" element={<MainPage />}/>
        </Routes>
      </BrowserRouter> */}
    </div>
  );
}

export default App;
