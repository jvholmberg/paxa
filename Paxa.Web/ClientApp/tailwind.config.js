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
          primaryLighter: "#abd9f4",
          primaryDark: "#0480b5",
          primaryDarker: "#0b5f88",
          accent: "#e9148c",
          accentLight: "#f051a3",
          accentDark: "#ba1470",

          black: "#354343",
          gray: "#8c8c8c1f",
        },
      },

    },
    container: {
      center: true,
    }
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
  ],
}
