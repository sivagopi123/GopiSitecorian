import React from 'react';
import _ from 'lodash';
import { Text, RichText } from '@sitecore-jss/sitecore-jss-react';

var possibleCombinationSum = function(arr, n) {
  if (arr.indexOf(n) >= 0) { return true; }
  if (arr[0] > n) { return false; }
  if (arr[arr.length - 1] > n) {
    arr.pop();
    return possibleCombinationSum(arr, n);
  }
  var listSize = arr.length, combinationsCount = (1 << listSize)
  for (var i = 1; i < combinationsCount ; i++ ) {
    var combinationSum = 0;
    for (var j=0 ; j < listSize ; j++) {
      if (i & (1 << j)) { combinationSum += arr[j]; }
    }
    if (n === combinationSum) { return true; }
  }
  return false;
};
const Stars = (props) => {
	//const numberOfStars = 1 + Math.floor(Math.random()*9);
  
  //Array method for looping through the star elements
  // let stars = [];
  // for (let i=0; i<numberOfStars; i++)
  // {
  // 	stars.push(<i key={i} className="fa fa-star"></i>);
  // }
	//Loop using the lodash library
  
	return (
  	<div className="col-5">
  			{_.range(props.randomNumberOfStars).map(i => 
        		<i key={i} className="fa fa-star"></i>
        )}
    </div>
  );
}
const Button = (props) => {
	let button;
  switch(props.answerIsCorrect){
  		case true:
      	button = <button className = "btn btn-success" onClick={props.acceptAnswer}>
      	  					<i className="fa fa-check"></i>
      						</button>;	
        break;
      case false:
				button = <button className = "btn btn-danger">
				  					<i className="fa fa-times"></i>
									</button>;
        break;
      default:
      	button = <button className="btn" 
        									onClick = {props.checkAnswer}
        									disabled={props.selectedNumbers.length === 0}>
        						=
                	</button>;
        break;
  }
	return (
  	<div className="col-2 text-center">
    	{button}
      <br /> <br />
      <button className="btn btn-warning btn-sm" disabled={props.redraws === 0} onClick={props.redraw}>
        <i className="fa fa-refresh"></i>{props.redraws}
      </button>
    </div>
  );
}
const Answer = (props) => {
	return (
		<div className="col-5">
    	{props.selectedNumbers.map((number,i) =>
      		<span key={i} onClick = {() => props.unselectedNumbers(number)}>
          	{number}
          </span>
      )}
		</div>
  );
}
const Numbers = (props) => {
	
	const numberClassName  = (number) => {
  		if(props.usedNumbers.indexOf(number) >= 0){
      		return 'used';
      }
  		if(props.selectedNumbers.indexOf(number) >= 0){
      		return 'selected';
      }
  }

	//This will create new instance of this variable whenever this component is called
	//const arrayOfNumbers = _.range(1,10);
	return (
  	<div className="card text-center">
  	  <div>
        {Numbers.list.map((number,i) =>
            <span key={i} className={numberClassName(number)}
             onClick = {() => props.selectNumber(number)}>
            {number}
            </span>
        )}
  	  </div>
  	</div>
  );
}

const DoneFrame = (props) => {
	return (
  	<div className="text-center">
    				<h2>{props.doneStatus}</h2>
  	        <button className="btn btn-secondary" onClick={props.resetGame}>Play Again</button>
  	</div>
  );
}

//This defines the list statically and will be rendered as a single instance for all the call made to //the Number component.
Numbers.list = _.range(1,10);
class Game extends React.Component{
  static randomNumber = () => 1 + Math.floor(Math.random()*9);
  static initialState = () => ({
  		selectedNumbers: [],
      randomNumberOfStars: Game.randomNumber(),
      answerIsCorrect:null,
      usedNumbers: [],
      redraws:5,
      doneStatus:null,
  });
	state = Game.initialState();
  selectNumber = (clickedNumber) => {
  	if(this.state.selectedNumbers.indexOf(clickedNumber) >= 0) { return; }
  	this.setState(prevState => ({
    		answerIsCorrect: null,
    		selectedNumbers: prevState.selectedNumbers.concat(clickedNumber)
    }));
  };
  unselectNumber = (clickedNumber) => {
  	this.setState(prevState => ({
    		answerIsCorrect: null,
    		selectedNumbers: prevState.selectedNumbers
        													.filter(number => number !== clickedNumber)
    }));
  };
  checkAnswer = () => {
  	//answerIsCorrect
    this.setState(prevState => ({
    		answerIsCorrect: prevState.randomNumberOfStars 
        === prevState.selectedNumbers.reduce((acc,n) => acc + n, 0)
    }));
  };
  acceptAnswer = () => {
  		this.setState(prevState => ({
      		usedNumbers:prevState.usedNumbers.concat(prevState.selectedNumbers),
          selectedNumbers:[],
          answerIsCorrect:null,
          randomNumberOfStars: Game.randomNumber(),
      }), this.updateDoneStatus);
  };
  redraw = () => {
  	if(this.state.redraws === 0) {return;}
  	this.setState(prevState =>({
    		randomNumberOfStars: Game.randomNumber(),
        answersIsCorrect:null,
        selectedNumbers:[],
        redraws: prevState.redraws -1
    }), this.updateDoneStatus);
  };
  possibleSolutions = ({randomNumberOfStars, usedNumbers}) => {
  			const possibleNumbers = _.range(1,10).filter(number => 
        										usedNumbers.indexOf(number) === -1);
        return possibleCombinationSum(possibleNumbers,randomNumberOfStars);
  }
  updateDoneStatus = () => {
  		this.setState(prevState => {
      		if(prevState.usedNumbers.length === 9){
          		return {doneStatus: 'Done. Nice!'};
          }
          if(prevState.redraws === 0 && !this.possibleSolutions(prevState)){
          		return {doneStatus: 'Game Over!'};
          }
      });
  };
  resetGame = () => this.setState(Game.initialState());
  
	render(){
  	return (
    	<div className="container">
        <hr />
        <div className="row">
					<Stars randomNumberOfStars = {this.state.randomNumberOfStars}/>
        	<Button selectedNumbers = {this.state.selectedNumbers}
          				checkAnswer = {this.checkAnswer}
                  answerIsCorrect = {this.state.answerIsCorrect}
                  acceptAnswer = {this.acceptAnswer}
                  redraw = {this.redraw}
                  redraws = {this.state.redraws}
          />
        	<Answer selectedNumbers = {this.state.selectedNumbers} 
          				unselectedNumbers = {this.unselectNumber} />
        </div>
        <br />
        {this.state.doneStatus ?
        		<DoneFrame resetGame = {this.resetGame} doneStatus = {this.state.doneStatus} /> :
            <Numbers selectedNumbers = {this.state.selectedNumbers} 
                    selectNumber={this.selectNumber} 
                    usedNumbers = {this.state.usedNumbers}/>
        }
        
      </div>
    );
  }
}
class App extends React.Component{
	render(){
  	return(
    	<div>
      	<Game />
      </div>
    );
  }
}

//ReactDOM.render(<App />, mountNode)


const NumberGame = (props) => (
    <React.Fragment>
    <Text tag="h2" className="display-4" field={props.fields.heading} />

    <RichText className="contentDescription" field={props.fields.content} />

    <App />
    </React.Fragment>
);

export default NumberGame;
