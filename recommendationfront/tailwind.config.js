/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}"],

  theme: {
    extend: {
      colors:{
        'primary': '#043873',
        'primary-light': '#4F9CF9',
        'secondary': '#FFE492',
        'secondary-light': '#A7CEFC',
        'secondary-dark': '#212529',
        'white': '#FFFFFF',
      },
      fontFamily: {
        //from assets/fonts
        
      }
    },
  },
  plugins: [],
}

