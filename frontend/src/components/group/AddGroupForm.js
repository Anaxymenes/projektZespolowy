import React, {Component} from 'react';
import {
    Form, 
    Input, 
    TextArea, 
    Button, 
    Label, 
    Image,
    Segment,
    Container,
    Header,
    Icon
} from 'semantic-ui-react';

const styles = {
    root: {
      display: 'flex',
      justifyContent: 'space-around',
      alignItems: 'center',
      height: '98vh',
      flexDirection: 'column'
    },
    segment: {
      background: "rgba(0, 0, 0, 0.6)"
    },
    input:{
        'border-bottom':"3px solid #333333",
        background: "transparent"
    },
    button: {
      "text-align": "center"
    }
  }
  
  const font = {
    root: {
      "fontSize": "20px",
      color: "white"
    },
    linkFont: {
      "fontSize": "20px",
      color:"rgb(190,190,190)"
    },
    h1: {
      "text-align": "center"
    }
  }
  
class AddGroupForm extends Component {
    state = { 
        groupName: '',
        groupDesc: '', 
        groupAvatar: [],
        imageUrl:''
    }

    handleChange = (e, { name, value }) => this.setState({ [name]: value })

    fileSelectedHandler = (e,value) => {
        // var file = e.target.files[0];
        // this.setState({groupAvatar: e.target.files[0]});
        // var reader = new FileReader();
        // var url = reader.readAsDataURL(file);
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
                groupAvatar: file
            })
        } 
        else {
            this.setState({
                imageUrl: ""
            })
        }

    }

    render() {
        const {groupName, groupDesc, groupAvatar} =this.state
        return (
            <div style = {styles.root}>
                <Segment inverted style = {styles.segment}>
                    <Container style={{'width': 900}}>
                    <Header as='h1' textAlign='center' inverted >
                        <Icon name='users' />
                            Dodaj grupę zainteresowań
                    </Header>
                        <Form>
                            <Form.Field>
                                <Form.Field>
                                    <label style = {font.root}>Nazwa grupy: </label>
                                </Form.Field>
                                <Input transparent style = {styles.input}
                                placeholder='Nazwij swoją grupę...'
                                name='groupName'
                                value={groupName}
                                onChange={this.handleChange}
                                />
                            </Form.Field>
                            <Form.Field>
                                <Form.Field>
                                    <label style = {font.root}>Opis grupy: </label>
                                </Form.Field>
                                <Input transparent style = {styles.input}
                                placeholder='Dodaj opis grupy...'
                                name='groupDesc'
                                value={groupDesc}
                                onChange={this.handleChange}
                                />
                            </Form.Field>
                            <Form.Field>
                                <Form.Field>
                                    <label style = {font.root}>Avatar grupy: </label>
                                </Form.Field>
                                <Input transparent
                                type='file'
                                accept="image/*"
                                name='groupAvatar'
                                //value={groupAvatar} 
                                onChange={this.fileSelectedHandler}
                                />
                            </Form.Field>
                                <Form.Field>
                                    <label style = {font.root}>Podgląd obrazka: </label>
                                </Form.Field>
                            <Image src={this.state.imageUrl} size='small' />
                            <Container textAlign="center">
                                <Button animated="vertical" 
                                    size="huge"  
                                    type="submit">
                                    <Button.Content visible>Dodaj</Button.Content>
                                    <Button.Content hidden>
                                        <Icon name="add" />
                                </Button.Content>
                                </Button>
                            </Container>

                        </Form>
                    </Container>
                </Segment>
            </div>
        );
    }
}

export default AddGroupForm;