```typescript

export {} // used to treat this file as module rathar than a script

//#region Basic_Types
let id: number = 5
let company: string = 'Insightin Technology'
let isPublished: boolean = true
let any: any = 'Hello'
let nullable: null = null
let undefine: undefined = undefined
let unknown: unknown = "unknown"
let object: object = {}
//typeof
//instanceof
//#endregion

//#region Any_VS_Unknown
any = 10
any = false
company = any

unknown = 20
unknown = true
//company = unknown  // Throws error
//#endregion

//#region Literal_Types
let literal: 'mzs' | 'munna' | 26
//literal = "mamun"  // Throws error
literal = "mzs"
literal = "munna"
literal = 26
//#endregion

//#region Type_Assertion
let cid: any = 1
let custId = <number>cid
let customerId = cid as number
(unknown as string).toUpperCase()
//#endregion

//#region Array
let num_arr1: number[] = [1, 2, 3, 4, 5]
let num_arr2: Array<number> = [1, 2, 3, 4, 5]
let arr_any1: any[] = [1, true, 'Hello']
let arr_any2: Array<any> = [1, true, 'Hello']
let str_num: [string, number] = ["Mzs", 26]

let array1: string[] = [] // = [] is needed to define the property as array otherwise you can't use array methods like : .push(), .pop(), .length(), etc
array1.push("Mzs")
//#endregion

//#region Tuple
let person: [number, string, boolean] = [1, 'Mzs', true]
// Tuple Array
let employees: [number, string][]

employees = [
  [1, 'Mzs'],
  [2, 'John'],
  [3, 'Jill'],
]
//#endregion

//#region Union
let pid: string | number
pid = '22'
//#endregion

//#region Enum
enum Direction1 {
  Up = 1,
  Down,
  Left,
  Right,
}

enum Direction2 {
  Up = 'Up',
  Down = 'Down',
  Left = 'Left',
  Right = 'Right',
}
//#endregion

//#region Objects
const user: {
  id: number
  name: string
  age: number

} = {
  id: 1,
  name: 'Mzs',
  age: 26
}
//#endregion

//#region Functions
function HelloWorld(){
  console.warn("Hello World")
}
HelloWorld()

function Hello(name: string){
  console.warn("Hello " + name)
}
Hello("Mzs")

function log(message: string | number): void {
  console.log(message)
}
log("Munna")
log(26)

let variableAsFunction: Function
variableAsFunction =  Hello
variableAsFunction("Mzs")

type AlphaNumeric = string | number
function Add(x: number, y: number): number
function Add(x: string, y: string): string
function Add(x: number, y: string): string
function Add(x: string, y: number): string
function Add(x: AlphaNumeric, y: AlphaNumeric): AlphaNumeric { //function Overloading
  
  if (typeof x === 'string' || typeof y === 'string'){
    return x.toString() + y.toString()
  } else{
    return x + y
  }
}

Add(5, "10")
Add(5, 10)
Add(5, "Mzs")
Add("Mzs", "Munna")
Add("Mzs", 26)

let calc: (x: number, y: number) => number //function signeture
calc = (num1: number, num2: number) => { return num1 + num2}

//Use of Never
function GenerateError(message: string, code: number): never {
  throw{ message:message, error: code}
}

GenerateError("Not found", 404)
//#endregion

//#region Interfaces
interface UserInterface {
  readonly id: number
  name: string
  age?: number
}

const user3: UserInterface = {
  id: 1,
  name: 'John',
}

interface MathFunc {
  (x: number, y: number): number
}

const add: MathFunc = (x: number, y: number): number => x + y
const sub: MathFunc = (x: number, y: number): number => x - y

interface PersonInterface {
  id: number
  name: string
  register(): string //register: ()=> string
}

interface ProductInterface {
  id: number
  name: string
  Purchase(): string //Purchase: ()=> string
}

interface StringKeysWithStringValues {
  [properties: string]: string
}

let skwsv: StringKeysWithStringValues = {
  name: "Mzs",
  //age: 18 //will throw error
  age: "18",
  1: "Munna" //won't throw error coz number can be convert to string
}

interface NumberKeysWithNumberValues {
  [properties: number]: number
}

let nkwnv: NumberKeysWithNumberValues = {
  //name: "Mzs", //will throw error
  //age: 18 //will throw error
  1: 18,
  2: 28,
  3: 3
}

interface StringKeysWithNumberValues {
  [properties: string]: number
}

let skwnv: StringKeysWithNumberValues = {
  //name: "Mzs", //will throw error
  1: 18, //won't throw error coz number can be convert to string
  notFound: 404,
  //age: 18 //will throw error
  InternalServerErros: 500,
  Success: 200
}

interface NumberKeysWithStringValues {
  [properties: number]: string
}

let nkwsv: NumberKeysWithStringValues = {
  //name: "Mzs", //will throw error
  //age: 18, //will throw error
  //age: "18", //will throw error
  1: "Mzs",
  2: "Munna"
}
//#endregion

//#region Classes
class Person implements PersonInterface {
  readonly id: number
  name: string // public name: string
  protected age?: number
  private gender?: string
  static email?: string
  //private address{ get; set;}: string

  //private constructor(id: number, name: string) { // a class constructor can be private as well! mostly used to implement Singleton
  constructor(id: number, name: string) {
    this.id = id
    this.name = name
  }

  get Name(): string{
    return this.name
  }
  
  set Name(name : string){
    this.name = name
  }
  
  register() {
    return `${this.name} is now registered`
  }
}

const brad = new Person(1, 'Mamunuz Zaman')
const mike = new Person(2, 'Mike Jordan')

class Product implements ProductInterface {
  quantity: number = 10
  constructor(readonly id: number, public name: string) {
    this.id = id
    this.name = name
  }
  Purchase() {
    return `${this.name} is now purchased`
  }
  GetQuantity() {
    console.log(this.quantity)
  }
}

const pen = new Product(1, 'Pen')
const phone = new Product(2, 'IPhone')

//#region Sub_Classes
class Employee extends Person {
  position: string
  constructor(id: number, name: string, position: string) {
    super(id, name)
    this.position = position
  }
}

const emp = new Employee(3, 'Mzs', 'Developer')
//#endregion

//#region Abstract_Classes
abstract class Mail {
  constructor(readonly to: string, public from: string, public message: string) {
    this.to = to
    this.from = from
    this.message = message
  }
  abstract SendMail(): void
}

class Email extends Mail {
  constructor(readonly to: string, public from: string, public message: string) {
    super(to, from, message)
  }
  SendMail() {
    return `Dear ${this.to},
	  ${this.message}
	  ${this.from}`
  }
}
//#endregion

//#region Type
type Combined = string | number | boolean
type StringNumber = string | number
type NumberBoolean = number | boolean
type CommonType = StringNumber & NumberBoolean
type CombinedClasses = Email & Mail
type UnionClasses = Email | Mail
type CombinedInterfaces = UserInterface & PersonInterface
type UnionInterfaces = UserInterface | PersonInterface

let combinable: Combined = "Mzs"
combinable = 26
let cmn : CommonType = 26

type User = {
  id: number
  name: string
}

const user1: User = {
  id: 1,
  name: 'John',
}

type Admin = {
  id: number
  name: string
  email: string
  role: string
}

type AdminUser = Admin & User

const adminUser: AdminUser = {
  id: 1,
  name: 'Mzs',
  email: 'mzs.munna@gmail.com',
  role: 'Developer'
}

type UserAdmin = User | Admin

const user2: UserAdmin = {
  id: 1,
  name: 'Mzs'
}

//console.log(user2.email) // will throw error so need a if check while passing as function parameter

function userHasEmail(user: UserAdmin): void {
  if('email' in user2){
    console.log(user2.email)
  }
}
userHasEmail(user2)

//#endregion

//#region Generics
function getArray<T>(items: T[]): T[] {
  return new Array().concat(items)
}

let numArray = getArray<number>([1, 2, 3, 4])
let strArray = getArray<string>(['Mamun', 'John', 'Jill'])

//strArray.push(1) // Throws error
numArray.push(1)

function getArray2<T, U>(items: T[], categories: U[]): U[] {
  return new Array().concat(categories)
}

let arrayRes = getArray2<number, string>([1, 2, 3, 4], ['Mamun', 'John', 'Jill'])

function genericExtendsArray1<T extends object>(items: T[]): T[] {
  return new Array().concat(items)
}

function genericExtendsArray2<T extends {name: string, age: number}>(items: T[]): T[] {
  return new Array().concat(items)
}

interface CustomInterface<T> {
  id: number
  name: T
}

const anObj: CustomInterface<string> = {
  id: 1,
  name: "custom",
}

let partialObj: Partial<CustomInterface<number>> = {} //Partial makes all the property value as optional
let actualObj = partialObj as CustomInterface<number>
let names: Readonly<string[]> = ["Mzs", "Munna"]

function genericExtendsArray3<T extends object, U extends keyof T>(object: T, key: U) {
  return object[key]
}

genericExtendsArray3(anObj, "name")

class ItemStorage<T> { //class ItemStorage<T extends string | number | boolean>
  private items: T[] = []

  AddItem(item: T){
    this.items.push(item)
  }

  RemoveItem(item: T){
    this.items.splice(this.items.indexOf(item), 1)
  }

  GetItems(item: T)
    return [...this.items]
  }

  GetItem(item: T){
    return this.items.indexOf(item)
  }
}

const textStorage = new ItemStorage<string>()
textStorage.AddItem("Mzs")
textStorage.AddItem("Munna")

const numStorage = new ItemStorage<number>()
numStorage.AddItem(1)
numStorage.AddItem(28)

const promise: Promise<string> = new Promise((resolve, reject) => {
  setTimeout(()=>{
    resolve("success");
  })
})

promise.then(data =>{
  data.split('')
})

const anptherPromise: Promise<number> = new Promise((resolve, reject) => {
  setTimeout(()=>{
    resolve(200);
  })
})

anptherPromise.then(data =>{
  //data.split('')  // Throws error
  data.toString()
})
//#endregion

//#region Decorator => // "experimentalDecorators": true,
function ClassDecorator(constructor: Function){
  console.warn("Logging... 1")
  console.warn(constructor)
}

function ClassDecorator2()
  return function(constructor: Function){
    console.warn("Logging... 2")
    console.warn(constructor)
  }
}

function ClassDecorator3(logString: string){
  return function(constructor: Function){
    console.warn("Logging... " + logString)
    console.warn(constructor)
  }
}

function ClassDecorator4(text: string, elementId: string){
  return function(constructor: any)
    let currDec = new constructor("Mzs")
    let dom = document.getElementById(elementId)//!
    if(dom)
      dom.innerHTML = "<h1>" + text + " " + currDec.name + "</h1>"
  }  
}

function ClassDecorator5(email : {text: string, elementId: string}){
  //return function<T extends {new(...args: any[]): any }>(constructor: T){
  return function<T extends {new(...args: any[]): {name: string, email: string} }>(constructor: T): T {
    // you can even return or modify existing constructor
    return class extends constructor {  
      constructor(...args: any[]){
        super()
        console.warn("Rendering Email Template... ")
        //let currDec = new constructor("Mzs")
        let dom = document.getElementById(email.elementId)//!
        if(dom)
          dom.innerHTML = "<h1>" + email.text + " " + this.name + "</h1>"
      }
      public SendEmail(name: string): void
      {
        console.warn("Email sent successful to : " + name)
      }
    }
  }  
}

function PropertyDecorator(target: any, propertyName: string | symbol){
	console.warn("Property Decorator... ")
	console.warn(target, propertyName)
}

function AccessorDecorator(target: any, memberName: string | symbol, propertyDescriptor: PropertyDescriptor){
  console.warn("Accessor Decorator... ")
  console.warn(target, memberName, propertyDescriptor)
}

function MethodDecorator(target: any, memberName: string | symbol, propertyDescriptor: PropertyDescriptor){
  console.warn("Method Decorator... ")
  console.warn(target, name, propertyDescriptor)
}

function ParameterDecorator(target: any, property: string | symbol, position: number){
  console.warn("Parameter Decorator... ")
  console.warn(target, property, position)
}

@ClassDecorator5({
  text: "Hello World", 
  elementId: "my_div_id"}
)
@ClassDecorator4("Hello World", "my_div_id")
@ClassDecorator3("Mzs")
@ClassDecorator2()
@ClassDecorator
class MyDecorator{

  @PropertyDecorator
  name: string
  email: string

  @AccessorDecorator
  set Email(value: string)
  {
    this.email = value
  }

  get Email()
  {
    return this.email
  }

  constructor(name: string, email: string) {
    this.name = name
    this.email = email
  }

  @MethodDecorator
  GetEmailWithName(@ParameterDecorator name: string): string
  {
    return "username : " + name + ", email : " + this.email
  }
}

const myDec = new MyDecorator("Mzs Munna", "mzs.munna@gmail.com")
//myDec.SendEmail() // throwing unknown error! Proper implementation of ClassDecorator5 will allow to called this method which defined inside the decorator method
//#endregion


//#region Module_Implementation
/*
1st => in tsconfig.jon file set -> "target": "es6", "module": "es2015",
2nd => in html script tag -> <script type="module" src="app.js"></script>
3rd => export Class_Name / Interface_Name / Method_Name / Enum_Name || export default Class_Name / Interface_Name / Method_Name / Enum_Name
4th => add on top of the file -> import { Class_Name / Interface_Name / Method_Name / Enum_Name } from './export_Class_file_location_with_filename.js' || import { Class_Name / Interface_Name / Method_Name / Enum_Name as Any_Name } from './export_Interface_file_location_with_filename.js' || import * as ANY_Name from './export_Interface_file_location_with_filename.js'
or
4th => use namespace for all grouped files and on top of the curent file add -> /// <reference path="./export_ClassOrInterface_file_location_with_filename.js" />
*/
//#endregion


//#region Namespace
namespace EntityNameSpace{
  export class Prospect{ // let's say this Prospect Class is available under EntityNameSpace in './ProspectModel.ts' file
    private username: string
    constructor(username: string){
      this.username = username
    }
    GetUserName(): string {
      return this.username
    }
  } 
}


/// <reference path="./ProspectModel.js" />
namespace EntityNameSpace{
  export class Member extends Prospect{ // let's say this Member Class is available under EntityNameSpace in './MemberModel.ts' file
    constructor(username: string){
      super(username)
    }
  }

  let prospect: Prospect = new EntityNameSpace.Prospect("Mzs Munna")
  let member: Member = new Member("Mamunuz Zaman")
  member.GetUserName()
}
//#endregion

//#region Symbol -> use Symbol as key of Object or as function of Class || every new Symbol instance has a unique Id but you never can't see!!
let symbol1 = Symbol() 
let symbol2 = Symbol("data_1")
let symbol3 = Symbol("data_2")
let symbolObj = {
  symbol1:"Mzs",
  [symbol2]:"Mzs"
}

console.warn(symbolObj.symbol1)
console.warn(symbolObj[symbol1])

class SymbolDemo{
  constructor(public name: any, private age: any, protected isMember: any){
    this.name = Symbol(name) 
    this.age = Symbol(age)
    this.isMember = Symbol(isMember)
  }
  [symbol3](){
    return "data for Symbol Demo => Name: " + this.name + " Age: " + this.age + " Member: " + this.isMember
  }
}

let symbolDemo = new SymbolDemo("Mamunuz",26,true)
console.warn(symbolDemo.name)
//console.warn(symbolDemo[symbol3]())
//#endregion

//#region DOM_Manipulation
const htmlFormElement = document.querySelector(".form_class_name") as HTMLFormElement
const htmlSelectElement = document.querySelector("#select_id_name") as HTMLSelectElement
const htmlInputElement = document.querySelector("#input_id_name") as HTMLInputElement
const htmlUListElement = document.querySelector("ul")! as HTMLUListElement // ! is used to ensure the compiler that the property won't be null
const htmlDivistElement = document.querySelector("div")! as HTMLDivElement
const htmlTemplateElement = document.querySelector("#template_id_name") as HTMLTemplateElement
const importNode = document.importNode(htmlTemplateElement.content, true)
htmlInputElement.value
htmlInputElement.valueAsNumber

const button = document.querySelector("button")! //as HTMLUListElement
button.addEventListener("click", pen.GetQuantity.bind(pen))
//#endregion 

//#region some useful npm command lines for TypeScript :
// npm install -g typescript

// some useful TSC command lines :
// tsc -v
// tsc --init
// tsc
// tsc filename
// tsc --watch || tsc -w filename
// tsc filename --outfile compiled_js_filename
// tsc *ts --watch
//#endregion

//#region some useful settings for tsconfig.jon :
// "include" : ["folderpath"] || set this outside of compilerOptions{} in tsconfig.jon file. This change will only allow ts files under that folder to be compiled into js
// "exclude" : ["filename","filepath","folderpath"]
// "rootDir": "./src",
// "outDir": "./public",
// "importHelpers": true,
// "target": "es5",
// "module": "es2015",
// "sourceMap": true,
// "removeComments": true,
// "noEmitOnError": true,
//#endregio

//#region WebPack
//WebPack
/*
//npm install --save-dev webpack webpack-cli webpack-dev-server typescript ts-loader (5 packages / dependencies)
//npm install --save-dev clean-webpack-plugin (1 extra package for prod)

const path = require('path');
//const CleanPlugin = require('clean-webpack-plugin'); //for production / live

module.exports = {
  mode: 'development', //mode: 'production', //for production / live 
  entry: './src/app.ts',
  output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'dist'),
    publicPath: 'dist' //for production / live this key is not needed 
  },
  devtool: 'inline-source-map', // devtool: 'none', //for production / live 
  module: {
    rules: [
      {
        test: /\.ts$/,
        use: 'ts-loader',
        exclude: /node_modules/
      }
    ]
  },
  resolve: {
    extensions: ['.ts', '.js']
  },
  // //for production / live
  //plugins: [
  //  new CleanPlugin.CleanWebpackPlugin()
  //]
};*/

//Package.json (NODE.JS)
/*{
  "name": "understanding-typescript",
  "version": "1.0.0",
  "description": "Understanding TypeScript Course Setup",
  "main": "app.js",
  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1",
    "start": "webpack-dev-server",
    "build": "webpack" //  "build": "webpack --config webpack.config.environment_name.js" //for mentioning different environmental webpack.config file rathar than the default one
  },
  "keywords": [
    "typescript",
    "course"
  ],
  "author": "Maximilian Schwarzmüller",
  "license": "ISC",
  "devDependencies": {
    //"clean-webpack-plugin": "^3.0.0", // for production / live
    "lite-server": "^2.5.4",
    "ts-loader": "^6.2.1",
    "typescript": "^3.7.2",
    "webpack": "^4.41.2",
    "webpack-cli": "^3.3.10",
    "webpack-dev-server": "^3.9.0"
  }
}*/
//#endregion