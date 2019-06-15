import React from 'react';
import Header from '../Header/index.js';
import Footer from '../Footer/index.js';
import BodyPane from '../BodyPane/index.js';

const TwoColumnWithHeader = (props) => (
  <div>
    <Header />
    <BodyPane />
    <Footer />
  </div>
);

export default TwoColumnWithHeader;