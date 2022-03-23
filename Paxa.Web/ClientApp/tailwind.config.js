module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          100: "#abd9f4",
          300: "#51b3e9",
          500: "#019fe3",
          700: "#0480b5",
          900: "#0b5f88",
        },
        accent: {
          300: "#f051a3",
          500: "#e9148c",
          700: "#ba1470",
        },

        brand: {

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
