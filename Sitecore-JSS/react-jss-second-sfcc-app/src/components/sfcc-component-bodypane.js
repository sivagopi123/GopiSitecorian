import React from 'react';

import LeftPane from './sfcc-component-leftpane.js';
import RightPane from './sfcc-component-rightpane.js';

class BodyPane extends React.Component{
  render(){
    return (
      <div className="col-12">
        <LeftPane />
        <RightPane />
      </div>
    );
  }
}

export default BodyPane;
