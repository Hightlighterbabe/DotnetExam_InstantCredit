import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import form from "./Pages/form";

const App = () => {
    return (
      <Layout>
        <Route exact path='/' component={form} />
      </Layout>
    );
}
export default App; 