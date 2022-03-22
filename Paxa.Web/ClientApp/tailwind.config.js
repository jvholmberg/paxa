module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        brand: {
          primary: "#019fe3",
          primaryLight: "#51b3e9",
          primaryDark: "#0480b5",
          accent: "#e9148c",
          accentLight: "#f051a3",
          accentDark: "#ba1470",
        }
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
  ],
}
