import React from 'react';
import axios from 'axios';
import { Text, RichText } from '@sitecore-jss/sitecore-jss-react';


const Card = (props) => {
	return (
  	<div style={{margin:'1em'}}>
      <img alt="" width="75" src={props.avatar_url}/>
      <div style={{display:'inline-block',marginLeft:10}}>
        <div style={{fontsize:'1.25em',fontWeight:'bold'}}>{props.name}</div>
        <div>{props.company}</div>
      </div>
    </div>
  );
};

const CardListDiv = (props) => {
	return (
  	<div>
  		{props.cards.map(card => <Card key={card.id} {...card}/>)} 
    </div>
  );
};

class Form extends React.Component {
	state = {userName: ''}
	handleSubmit = (event) => {
  	event.preventDefault();
    //let text = getElementById("#GitHubSubmit");
    //console.log('Event: form submit', this.state.userName);
    //ajax ..fetch or axios
    axios.get(`https://api.github.com/users/${this.state.userName}`)
    	.then(resp => {
      	this.props.onSubmit(resp.data);
        this.setState({userName: ''});
      });
  }
	render(){
  	return (
    	<form onSubmit={this.handleSubmit}>
      	<input 
        	type="text" 
          value={this.state.userName} //this is the controlled element
          onChange={(event) => this.setState({userName:event.target.value})}
          placeholder="Github Username" 
          required/>
        <button type="submit">Add card</button>
      </form>
    );
  }
}

class App extends React.Component {
  state = {
    cards : []
  };
  
  addNewCard = (cardInfo) => {
      this.setState(prevState => ({
       cards: prevState.cards.concat(cardInfo)
      }));
  };
  
	render(){
    return(
      <div>
        <Form onSubmit={this.addNewCard}/>
        <CardListDiv cards={this.state.cards} />
      </div>
      );
	}	
}


const CardList = (props) => (
  <React.Fragment>
  <Text tag="h2" className="display-4" field={props.fields.heading} />

  <RichText className="contentDescription" field={props.fields.content} />

  <App />
  </React.Fragment>
);

export default CardList;