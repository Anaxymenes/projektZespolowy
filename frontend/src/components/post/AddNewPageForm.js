import React, {Component} from 'react';
import {
  Button,
  Dropdown,
  FormField,
  Form,
  Input
} from 'semantic-ui-react';
import Validator from 'validator';
import PropTypes from 'prop-types';
import '../../style/style.css';



const options = [
  {
    value: 'sport',
    text: 'Sport'
  }, {
    value: 'gotowanie',
    text: 'Gotowanie'
  }, {
    value: 'spanie',
    text: 'Spanie'
  }, {
    value: 'zbieranieGrzybow',
    text: 'Zbieranie Grzybow'
  }
]
/*
const styles = {
  column:{
    'padding-top': '35px',
    'padding-bottom': '75px',
    'padding-left': '75px',
    'padding-right': '75px'
  },
  container:{
    'background-color': 'rgba(0,0,0,0.7)',
    padding:"20px"
  },
  h1:{
    'text-align':'center',
    color: 'white',
    'font-size': '25px'
  },
  h2:{
    'text-align':'center',
    color: 'white',
    'font-size': '25px'
  },
  h3:{
    'text-align':'left',
    color: 'white',
    'font-size': '15px'
  },
  textArea:{
    background:'rgba(0,0,0,0.7)',
    color: 'white',
  },
  input:{
    background:'rgba(0,0,0,0.7)',
    border: '1px solid white',
  },
  button:{
    color:'rgb(0,0,0)',
    margin: '15px',
    
  }
};
*/


class AddNewPageForm extends Component {
  componentWillMount() {
    this.setState({
      data: {
        content: '',
        postPhoto: [],
        imageUrl: '',
        toGroup: [],
        place: ''
      },
      withPhoto: false,
      withPlace: false
      
      
    })
    this.onCheckBoxChangePhoto=this.onCheckBoxChangePhoto.bind(this);
    this.onCheckBoxChangePlace=this.onCheckBoxChangePlace.bind(this);
  }

  onChange = e => {
    this.setState({
    data: {
      ...this.state.data,
      [e.target.name]: e.target.value
    },
  });
}

  onCheckBoxChangePhoto(e) {
    this.setState({
      withPhoto: !this.state.withPhoto,
      data:{
        postPhoto: [],
        imageUrl: ''
      }   
    });
    
  }
  onCheckBoxChangePlace(e) {
    this.setState({withPlace: !this.state.withPlace});
  }

  onChangeGroups = (e, {value}) => this.setState({
    data: {
      ...this.state.data,
      toGroup: value
    }
  });

  onSubmit = (event) => {
    event.preventDefault();
    const errors = this.validate(this.state.data);
    this.setState({errors});
    if (!this.state.isError) {
      this
        .props
        .submit(this.state.data)
      // TODO when Api ready .catch(err => this.setState({errors:
      // err.response.data.errors, loading: false}))
    }
  }
  validate = (data) => {
    const errors = {};
    this.setState({isError: false});
    //Validate content;
    errors.content = "";
    if (!Validator.isLength(data.content, 1, 1000)) 
      errors.content += "Post musi mieć od 1 do 100 znaków";
    
    //Validate forGroups
    errors.forGroups = "";
    return errors;
  }

  fileSelectedHandler = (e,value) => {
    const file    = e.target.files[0];
    const reader  = new FileReader();
  
    reader.onloadend = () => {
        this.setState({
            imageUrl: reader.result
        })
    }
    if (file) {
        reader.readAsDataURL(file);
        this.setState({
            imageUrl :reader.result,
            postPhoto: file
        })
    } 
    else {
        this.setState({
            imageUrl: ""
        })
    }
  }
  

  render() {
    const {data, withPhoto, withPlace} = this.state;
    return (
      <div className="container mw-100 h-100">
        <div className="row h-100">
          <div className="col border column">
            <div className="container h-100 container1 border">
              <h1 className="h1">Dodaj post</h1>
              <div className="form-group">
                <h3 className="h3">Treść</h3>
                <textarea className="form-control textArea"  rows="4"></textarea>
              </div>
              <h3 className="h3">Dodaj grupy</h3>
              <FormField>
                      <Dropdown className="input"
                        placeholder='Dodaj do...'
                        name="forGroup"
                        fluid
                        multiple
                        search
                        selection
                        options={options}
                        value={data.toGroup}
                        onChange={this.onChangeGroups}/>
              </FormField> 
              <div className="row">
                <div className="col">
                <input className="button"
                    type='file'
                    accept="image/*"
                    name='postPhoto'
                    onChange={this.fileSelectedHandler}
                    />
                </div> 
                <div className="col">
                  <Button className="button" floated="left" content='Miejsce' icon='map' color='grey' labelPosition='left' />
                </div>  
              </div>   
            </div> 
          </div> 
          <div className="col column border">
            <div className="container h-100 container1 border">
               <h2 className="h2">Podgląd</h2>
            </div> 
          </div>
        </div>
      </div>
    );
  }
}

AddNewPageForm.propTypes = {
  submit: PropTypes.func
}

export default AddNewPageForm;