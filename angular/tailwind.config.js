/** @type {import('tailwindcss').Config} */
const colors = require('tailwindcss/colors')
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
    "./node_modules/flowbite/**/*.js"
  ],
  theme: {
    extend: {
      'animation': {
        'text': 'text 5s ease infinite',
      },
      'keyframes': {
        'text': {
          '0%, 100%': {
            'background-size': '200% 200%',
            'background-position': 'left center'
          },
          '50%': {
            'background-size': '200% 200%',
            'background-position': 'right center'
          }
        },
      },
      colors: {
        'light-blue': colors.lightBlue,
        cyan: colors.cyan,
        // myPrimaryColor: '#2cc693' ,
        myPrimaryColor: '#3f51b5',
        greenStat: '#2cc693',
        redStat: '#3f51b5',
        orangeStat: 'red',

      },
    },
  },
  variants: {},
  plugins: [
    require('flowbite/plugin'),
    require('@tailwindcss/line-clamp'),
  ],
}
