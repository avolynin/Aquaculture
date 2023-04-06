import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import AuthPage from './pages/auth-page/auth-page';
import MeasurementsPage from './pages/measurements-page/measurements-page';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<AuthPage />}/>
          <Route path="/tmp" element={<MeasurementsPage />}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
