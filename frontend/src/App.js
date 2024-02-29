import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import './App.scss';
import Footer from './components/footer/footer';
import Navbar from './components/navbar/navbar';
import WebRoutes from './routes/routes';
import { checkIfUserIsAlreadyLoggedIn } from './store/reducers/user/userSlice';
import { history } from './utils/history';

function App() {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(checkIfUserIsAlreadyLoggedIn());
  }, []);

  return (
    <div>
      <BrowserRouter history={history}>
        <div className="flex flex-col items-stretch min-h-screen w-screen">
          <Navbar />
          <WebRoutes />
          <Footer />
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
