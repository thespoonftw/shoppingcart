import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Shop } from './components/Shop';
import { Header } from './components/Header';

import './custom.css'

function App() {
  return (
    <div>
      <Header />
      <Shop />
    </div>    
  )
}

export default App;